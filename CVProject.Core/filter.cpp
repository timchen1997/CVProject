#include "CVProject.Core.h"
#include "image.h"
#include <cstdlib>
#include <vector>
#include <algorithm>
#include <cmath>
#include <stack>
#include <queue>

#define PI 3.14159265358979323846264338327950288

static void convolute(unsigned char *img, int width, int height, double *kernel, int size, signedPixel *newimg) {
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
			auto p = SIGNEDPIXEL(newimg, width, i, j);
			p->r = tr;
			p->g = tg;
			p->b = tb;
		}
}

CVPROJECTCORE_API void smooth(unsigned char *img, int width, int height, double *kernel, int size) {
	signedPixel *newimg = (signedPixel *)malloc(sizeof(signedPixel) * width * height);
	convolute(img, width, height, kernel, size, newimg);
	for (int i = size / 2; i < height - size / 2; i++)
		for (int j = size / 2; j < width - size / 2; j++) {
			auto p = PIXEL(img, width, i, j);
			auto sp = SIGNEDPIXEL(newimg, width, i, j);
			p->r = (unsigned char)std::min(abs(sp->r), 255);
			p->g = (unsigned char)std::min(abs(sp->g), 255);
			p->b = (unsigned char)std::min(abs(sp->b), 255);
		}
	free(newimg);
}

CVPROJECTCORE_API void smoothMedian(unsigned char *img, int width, int height, int size) {
	unsigned char *newimg = (unsigned char *)malloc(sizeof(unsigned char) * width * height * 4);
	unsigned char *vr = (unsigned char *)malloc(sizeof(unsigned char) * size * size);
	unsigned char *vg = (unsigned char *)malloc(sizeof(unsigned char) * size * size);
	unsigned char *vb = (unsigned char *)malloc(sizeof(unsigned char) * size * size);
	for (int i = size / 2; i < height - size / 2; i++)
		for (int j = size / 2; j < width - size / 2; j++) {
			for (int a = 0; a < size; a++)
				for (int b = 0; b < size; b++) {
					auto p = PIXEL(img, width, i + a - size / 2, j + b - size / 2);
					vr[a * size + b] = p->r;
					vg[a * size + b] = p->g;
					vb[a * size + b] = p->b;
				}
			std::nth_element(vr, vr + size * size / 2, vr + size * size);
			std::nth_element(vg, vg + size * size / 2, vg + size * size);
			std::nth_element(vb, vb + size * size / 2, vb + size * size);
			auto p = PIXEL(newimg, width, i, j);
			p->r = vr[size * size / 2];
			p->g = vg[size * size / 2];
			p->b = vb[size * size / 2];
		}
	for (int i = size / 2; i < height - size / 2; i++)
		for (int j = size / 2; j < width - size / 2; j++)
			*PIXEL(img, width, i, j) = *PIXEL(newimg, width, i, j);
	free(newimg);
	free(vr);
	free(vg);
	free(vb);
}

CVPROJECTCORE_API void sobel(unsigned char *img, int width, int height, int size) {
	signedPixel *imgx = (signedPixel *)malloc(sizeof(signedPixel) * width * height);
	signedPixel *imgy = (signedPixel *)malloc(sizeof(signedPixel) * width * height);
	memset(imgx, 0, sizeof(signedPixel) * width * height);
	memset(imgy, 0, sizeof(signedPixel) * width * height);
	double gx[9] = { -1, 0, 1, -2, 0, 2, -1, 0, 1 };
	double gy[9] = { -1, -2, -1, 0 ,0 ,0, 1, 2, 1 };
	convolute(img, width, height, gx, 3, imgx);
	convolute(img, width, height, gy, 3, imgy);
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			auto px = SIGNEDPIXEL(imgx, width, i, j);
			auto py = SIGNEDPIXEL(imgy, width, i, j);
			p->r = (unsigned char)std::min(sqrt(px->r * px->r + py->r * py->r), 255.0);
			p->g = (unsigned char)std::min(sqrt(px->g * px->g + py->g * py->g), 255.0);
			p->b = (unsigned char)std::min(sqrt(px->b * px->b + py->b * py->b), 255.0);
		}
	free(imgx);
	free(imgy);
}


CVPROJECTCORE_API void laplacian(unsigned char *img, int width, int height, int mode) {
	signedPixel *newimg = (signedPixel *)malloc(sizeof(signedPixel) * width * height);
	memset(newimg, 0, sizeof(signedPixel) * width * height);
	if (mode == 0) {
		double kernel[9] = { 0, 1, 0, 1, -4, 1, 0, 1, 0 };
		convolute(img, width, height, kernel, 3, newimg);
	}
	else {
		double kernel[9] = { 1, 1, 1, 1, -8, 1, 1, 1, 1 };
		convolute(img, width, height, kernel, 3, newimg);
	}
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			auto sp = SIGNEDPIXEL(newimg, width, i, j);
			p->r = (unsigned char)std::min(abs(sp->r), 255);
			p->g = (unsigned char)std::min(abs(sp->g), 255);
			p->b = (unsigned char)std::min(abs(sp->b), 255);
		}
	free(newimg);
}

static void genGaussKernel(double *kernel, int size) {
	double sum = 0, sigma = 1;
	int center = size / 2;
	for (int i = 0; i < size; i++)
	{
		double x2 = pow(i - center, 2);
		for (int j = 0; j < size; j++)
		{
			double y2 = pow(j - center, 2);
			double g = exp(-(x2 + y2) / (2 * sigma * sigma));
			g /= 2 * PI * sigma;
			sum += g;
			kernel[i * size + j] = g;
		}
	}
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			kernel[i * size + j] /= sum;
		}
	}
}

CVPROJECTCORE_API void canny(unsigned char *img, int width, int height, int size, int lthreshold, int rthreshold) {
	double *gaussKernel = (double *)malloc(size * size * sizeof(double));
	genGaussKernel(gaussKernel, size);
	smooth(img, width, height, gaussKernel, size);

	signedPixel *imgx = (signedPixel *)malloc(sizeof(signedPixel) * width * height);
	signedPixel *imgy = (signedPixel *)malloc(sizeof(signedPixel) * width * height);
	int *direction = (int *)malloc(sizeof(int) * width * height);
	memset(imgx, 0, sizeof(signedPixel) * width * height);
	memset(imgy, 0, sizeof(signedPixel) * width * height);
	double gx[9] = { -1, 0, 1, -2, 0, 2, -1, 0, 1 };
	double gy[9] = { -1, -2, -1, 0 ,0 ,0, 1, 2, 1 };
	convolute(img, width, height, gx, 3, imgx);
	convolute(img, width, height, gy, 3, imgy);
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			auto px = SIGNEDPIXEL(imgx, width, i, j);
			auto py = SIGNEDPIXEL(imgy, width, i, j);
			p->r = (unsigned char)std::min(sqrt(px->r * px->r + py->r * py->r), 255.0);
			p->g = (unsigned char)std::min(sqrt(px->g * px->g + py->g * py->g), 255.0);
			p->b = (unsigned char)std::min(sqrt(px->b * px->b + py->b * py->b), 255.0);
			double angle = atan2(py->r, px->r);
			if (angle >= -PI / 8 && angle < PI / 8)
				direction[i * width + j] = 0;
			else if (angle >= PI / 8 && angle < PI * 3 / 8)
				direction[i * width + j] = 1;
			else if (angle >= PI * 3 / 8 && angle < PI * 5 / 8)
				direction[i * width + j] = 2;
			else if (angle >= PI * 5 / 8 && angle < PI * 7 / 8)
				direction[i * width + j] = 3;
			else if (angle >= PI * 7 / 8 || angle < -PI * 7 / 8)
				direction[i * width + j] = 0;
			else if (angle >= -PI * 7 / 8 && angle < -PI * 5 / 8)
				direction[i * width + j] = 1;
			else if (angle >= -PI * 5 / 8 && angle < -PI * 3 / 8)
				direction[i * width + j] = 2;
			else
				direction[i * width + j] = 3;
		}
	free(imgx);
	free(imgy);

	int dy[8] = { -1, -1, 0, 1, 1, 1, 0, -1};
	int dx[8] = { 0, -1, 1, -1, 1, 0, -1, 1};
	for (int i = 1; i < height - 1; i++)
		for (int j = 1; j < width - 1; j++) {
			auto p = PIXEL(img, width, i, j);
			int d = direction[i * width + j];
			auto sp = PIXEL(img, width, i + dx[d], j + dy[d]);
			auto pp = PIXEL(img, width, i - dx[d], j - dy[d]);
			if (p->r < sp->r || p->r < pp->r)
				p->r = p->g = p->b = 0;
		}
	free(direction);

	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			if (p->r < lthreshold)
				p->r = p->g = p->b = 0;
		}

	bool connected = false;
	std::stack<std::pair<int, int>> s;
	std::queue<std::pair<int, int>> q;
	bool *marked = (bool *)malloc(sizeof(bool) * width * height);
	memset(marked, 0, sizeof(bool) * width * height);
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			if (p->r >= lthreshold && p->r < rthreshold && !marked[i * width + j]) {
				s.push(std::make_pair(i, j));
				q.push(std::make_pair(i, j));
				marked[i * width + j] = true;
				while (!s.empty()) {
					auto cur = s.top();
					s.pop();
					for (int k = 0; k < 8; k++) {
						int ti = i + dx[k];
						int tj = j + dy[k];
						if (OUTSIDE(width, height, ti, tj)) continue;
						auto p = PIXEL(img, width, ti, tj);
						if (p->r >= lthreshold && p->r < rthreshold && !marked[ti * width + tj]) {
							s.push(std::make_pair(ti, tj));
							q.push(std::make_pair(ti, tj));
							marked[ti * width + tj] = true;
						}
						else if (p->r >= rthreshold) {
							connected = true;
						}
					}
				}
				if (!connected) {
					while (!q.empty()) {
						auto t = q.front();
						auto p = PIXEL(img, width, t.first, t.second);
						p->r = p->g = p->b = 0;
						q.pop();
					}
				}
				else {
					while (!q.empty()) q.pop();
					connected = false;
				}
			}
		}
}
