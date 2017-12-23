#include "CVProject.Core.h"
#include "image.h"
#include <cstdlib>
#include <vector>
#include <algorithm>

CVPROJECTCORE_API void smooth(unsigned char *img, int width, int height, double *kernel, int size) {
	unsigned char *newimg = (unsigned char *)malloc(sizeof(unsigned char) * width * height * 4);
	for (int i = size / 2; i < height - size / 2; i++)
		for (int j = size / 2; j < width - size / 2; j++) {
			double tr = 0, tg = 0, tb = 0;
			for (int a = 0; a < size; a++)
				for (int b = 0; b < size; b++) {
					auto p = PIXEL(img, width, i + a - size / 2, j + b - size / 2);
					auto k = KERNELITEM(kernel, size, a, b);
					tr += p->r * k;
					tg += p->g * k;
					tb += p->b * k;
				}
			auto p = PIXEL(newimg, width, i, j);
			p->r = tr;
			p->g = tg;
			p->b = tb;
		}
	for (int i = size / 2; i < height - size / 2; i++)
		for (int j = size / 2; j < width - size / 2; j++)
			*PIXEL(img, width, i, j) = *PIXEL(newimg, width, i, j);
	free(newimg);
}

CVPROJECTCORE_API void smoothMedian(unsigned char *img, int width, int height, int size) {
	unsigned char *newimg = (unsigned char *)malloc(sizeof(unsigned char) * width * height * 4);	
	for (int i = size / 2; i < height - size / 2; i++)
		for (int j = size / 2; j < width - size / 2; j++) {
			std::vector<unsigned char> vr, vg, vb;
			for (int a = 0; a < size; a++)
				for (int b = 0; b < size; b++) {
					auto p = PIXEL(img, width, i + a - size / 2, j + b - size / 2);
					vr.push_back(p->r);
					vg.push_back(p->g);
					vb.push_back(p->b);
				}
			std::sort(vr.begin(), vr.end());
			std::sort(vg.begin(), vg.end());
			std::sort(vb.begin(), vb.end());
			auto p = PIXEL(newimg, width, i, j);
			p->r = vr[size / 2];
			p->g = vg[size / 2];
			p->b = vb[size / 2];
		}
	for (int i = size / 2; i < height - size / 2; i++)
		for (int j = size / 2; j < width - size / 2; j++)
			*PIXEL(img, width, i, j) = *PIXEL(newimg, width, i, j);
	free(newimg);
}