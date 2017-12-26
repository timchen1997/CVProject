#include "CVProject.Core.h"
#include "image.h"
#include <cstring>
#include <cstdlib>
#include <cmath>
#include <algorithm>

CVPROJECTCORE_API void histogramBalance(unsigned char *img, int width, int height) {
	int count[256], newValue[256];
	memset(count, 0, sizeof(count));
	memset(newValue, 0, sizeof(newValue));
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			count[p->r]++;
		}
	for (int i = 0; i < 256; i++) {
		if (i) count[i] += count[i - 1];
		newValue[i] = round(count[i] / (double)(width * height) * 255);
	}
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			p->r = p->g = p->b = newValue[p->r];
		}
}

CVPROJECTCORE_API void contrastLinear(unsigned char *img, int width, int height, unsigned char x1, unsigned char x2, unsigned char y1, unsigned char y2) {
	unsigned char newValue[256];
	for (int i = 0; i < 256; i++) {
		if (i <= x1)
			newValue[i] = round((double)i / x1 * y1);
		else if (i <= x2)
			newValue[i] = round((double)(i - x1) / (x2 - x1) * (y2 - y1) + y1);
		else
			newValue[i] = round((double)(i - x2) / (255 - x2) * (255 - y2) + y2);
	}
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			p->r = newValue[p->r];
			p->g = newValue[p->g];
			p->b = newValue[p->b];
		}
}

CVPROJECTCORE_API void contrastLog(unsigned char *img, int width, int height, double c) {
	unsigned char newValue[256];
	for (int i = 0; i < 256; i++) {
		double t = round(log(i + 1) * c);
		t = std::max(t, 0.0);
		t = std::min(t, 255.0);
		newValue[i] = t;
	}
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			p->r = newValue[p->r];
			p->g = newValue[p->g];
			p->b = newValue[p->b];
		}
}

CVPROJECTCORE_API void contrastExp(unsigned char *img, int width, int height, double c) {
	unsigned char newValue[256];
	for (int i = 0; i < 256; i++) {
		double t = round(exp(i) * c);
		t = std::max(t, 0.0);
		t = std::min(t, 255.0);
		newValue[i] = t;
	}
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			p->r = newValue[p->r];
			p->g = newValue[p->g];
			p->b = newValue[p->b];
		}
}