#include "CVProject.Core.h"
#include "image.h"
#include <cstring>
#include <cstdlib>
#include <cmath>

CVPROJECTCORE_API void histogramBalance(unsigned char *img, int width, int height) {
	int count[256], newValue[256];
	memset(count, 0, sizeof(count));
	memset(newValue, 0, sizeof(newValue));
	for (int i = 0; i < height; i++)
		for (int j = 0; j < height; j++) {
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