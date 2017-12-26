#include "CVProject.Core.h"
#include "image.h"
#include <cmath>
#include <cstring> 
#include <algorithm>

#define PI 3.14159265358979323846264338327950288

const int dx[8] = { 1, 1, 0, -1, -1, -1, 0, 1 };
const int dy[8] = { 0, 1, 1, 1, 0, -1, -1, -1 };

CVPROJECTCORE_API int houghLine(unsigned char *img, int width, int height, int threshold, int* lineList) {
	int top = 0;
	int rMax = sqrt(width * width + height * height);
	int *count = (int *)malloc(sizeof(int) * (rMax + 1) * 720);
	memset(count, 0, sizeof(int) * (rMax + 1) * 720);
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			if (p->r > 0)
				for (int k = 0; k < 720; k++) {
					int r = round(i * cos(k / 360.0 * PI) + j * sin(k / 360.0 * PI));
					if (r > 0)
						count[r * 720 + k]++;
				}
		}
	for (int i = 0; i <= rMax; i++)
		for (int j = 0; j < 720; j++) {
			if (count[i * 720 + j] >= threshold) {
				for (int k = 0; k < 8; k++) {
					int ni = i + dx[k], nj = j + dy[k];
					if (OUTSIDE(720, rMax, ni, nj)) continue;
					if (count[i * 720 + j] < count[ni * 720 + nj])
						goto next;
				}
				for (int k = 0; k < top / 2; k++)
					if (abs(lineList[k * 2] - i) <= 16 && abs(lineList[k * 2 + 1] - j / 2) <= 16)
						goto next;
				lineList[top++] = i;
				lineList[top++] = j / 2;
			}
		next:;
		}
	return top / 2;
}

CVPROJECTCORE_API int houghCircle(unsigned char *img, int width, int height, int threshold, int rMin, int rMax, int* circleList) {
	int top = 0;
	int *count = (int *)malloc(sizeof(int) * (width + 1) * (height + 1));
	for (int r = rMin; r <= rMax; r++) {
		memset(count, 0, sizeof(int) * (width + 1) * (height + 1));
		for (int i = 0; i < height; i++)
			for (int j = 0; j < width; j++) {
				auto p = PIXEL(img, width, i, j);
				if (p->r > 0)
					for (int k = 0; k < width; k++) {
						int b = round(i - sqrt(r * r - (j - k) * (j - k)));
						if (b > 0 && b < height)
							count[b * width + k]++;
					}
			}
		for (int i = 0; i <= height; i++)
			for (int j = 0; j < width; j++) {
				if (count[i * width + j] >= threshold) {
					for (int k = 0; k < 8; k++) {
						int ni = i + dx[k], nj = j + dy[k];
						if (OUTSIDE(width, height, ni, nj)) continue;
						if (count[i * width + j] < count[ni * height + nj])
							goto next;
					}
					for (int k = 0; k < top / 3; k++)
						if (abs(circleList[k * 3] - i) <= 6 && abs(circleList[k * 3 + 1] - j) <= 6 && abs(circleList[k * 3 + 2] - r) <= 6)
							goto next;
					circleList[top++] = i;
					circleList[top++] = j;
					circleList[top++] = r;
				}
			next:;
			}
	}
	return top / 3;
}