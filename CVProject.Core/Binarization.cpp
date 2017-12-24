#include "CVProject.Core.h"
#include "image.h"
#include <cstring>

static bool check(pixel *p, bool RInOut, unsigned char RLow, unsigned char RHigh, 
	bool GInOut, unsigned char GLow, unsigned char GHigh, bool BInOut, unsigned char BLow, unsigned char BHigh) {
	if (!RInOut && (p->r < RLow || p->r > RHigh)) return false;
	if (RInOut && p->r >= RLow && p->r <= RHigh) return false;
	if (!GInOut && (p->g < GLow || p->g > GHigh)) return false;
	if (GInOut && p->g >= GLow && p->g <= GHigh) return false;
	if (!BInOut && (p->b < BLow || p->b > BHigh)) return false;
	if (BInOut && p->b >= BLow && p->b <= BHigh) return false;
	return true;
}

static inline double sqr(double a) {
	return a * a;
}

CVPROJECTCORE_API void binarizeImg(unsigned char* img, int width, int height, bool RInOut, unsigned char RLow, unsigned char RHigh, 
	bool GInOut, unsigned char GLow, unsigned char GHigh, bool BInOut, unsigned char BLow, unsigned char BHigh) {
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			if (check(p, RInOut, RLow, RHigh, GInOut, GLow, GHigh, BInOut, BLow, BHigh)) {
				p->b = 255;
				p->g = 255;
				p->r = 255;
			}
			else {
				p->b = 0;
				p->g = 0;
				p->r = 0;
			}
		}
}

CVPROJECTCORE_API void binarizeImgOtsu(unsigned char* img, int width, int height) {
	int grayCount[256];
	double grayPro[256], maxPro = 0;
	toGrayScale(img, width, height, 0);
	memset(grayCount, 0, sizeof(grayCount));
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++)
			grayCount[PIXEL(img, width, i, j)->r]++;
	for (int i = 0; i < 256; i++)
		grayPro[i] = (double)grayCount[i] / (width * height);
	double maxDelta = 0;
	int threshold;
	for (int i = 0; i < 256; i++) {
		double w0 = 0, w1 = 0, u0 = 0, u1 = 0, u, tDelta;
		for (int j = 0; j <= i; j++) {
			w0 += grayPro[j];
			u0 += j * grayPro[j];
		}
		for (int j = i + 1; j < 256; j++) {
			w1 += grayPro[j];
			u1 += j * grayPro[j];
		}
		u = u0 + u1;
		u0 /= w0;
		u1 /= w1;
		tDelta = w0 * sqr(u0 - u) + w1 * sqr(u1 - u);
		if (tDelta > maxDelta) {
			maxDelta = tDelta;
			threshold = i;
		}
	}
	binarizeImg(img, width, height, false, threshold, 255, false, threshold, 255, false, threshold, 255);
}