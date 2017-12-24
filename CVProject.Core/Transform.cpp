#include "CVProject.Core.h"
#include "image.h"
#include <cstdlib>
#include <cmath>
#include <cstring>

enum TRANSFORMMODE {NEAR = 0, LINEAR};

CVPROJECTCORE_API unsigned char *resize(unsigned char *img, int width, int height, int nwidth, int nheight, unsigned char mode) {
	unsigned char *newimg = (unsigned char *)malloc(sizeof(unsigned char) * nwidth * nheight * 4);
	for (int i = 0; i < nheight; i++)
		for (int j = 0; j < nwidth; j++) {
			double oi = (double)i / (nheight - 1) * (height - 1), oj = (double)j / (nwidth - 1) * (width - 1);
			if (mode == NEAR)
				*PIXEL(newimg, nwidth, i, j) = *PIXEL(img, width, (int)round(oi), (int)round(oj));
			else {
				auto foi = (int)floor(oi), coi = (int)floor(oi + 1), foj = (int)floor(oj), coj = (int)floor(oj + 1);
				auto p1 = PIXEL(img, width, foi, foj);
				auto p2 = PIXEL(img, width, foi, coj >= width ? foj : coj);
				pixel t1 = { p1->b * (coj - oj) + p2->b * (oj - foj),
					p1->g * (coj - oj) + p2->g * (oj - foj),
					p1->r * (coj - oj) + p2->r * (oj - foj),
					p1->a * (coj - oj) + p2->a * (oj - foj) };
				p1 = PIXEL(img, width, coi >= height ? foi : coi, foj);
				p2 = PIXEL(img, width, coi >= height ? foi : coi, coj >= width ? foj : coj);
				pixel t2 = { p1->b * (coj - oj) + p2->b * (oj - foj),
					p1->g * (coj - oj) + p2->g * (oj - foj),
					p1->r * (coj - oj) + p2->r * (oj - foj),
					p1->a * (coj - oj) + p2->a * (oj - foj) };
				*PIXEL(newimg, nwidth, i, j) = { (unsigned char)(t1.b * (coi - oi) + t2.b * (oi - foi)),
					(unsigned char)(t1.g * (coi - oi) + t2.g * (oi - foi)),
					(unsigned char)(t1.r * (coi - oi) + t2.r * (oi - foi)),
					(unsigned char)(t1.a * (coi - oi) + t2.a * (oi - foi)) };
			}
		}
	return newimg;
}

static inline void matmul(double *a, double *b) {
	double *r = (double *)malloc(3 * sizeof(double));
	r[0] = a[0] * b[0] + a[1] * b[3] + a[2] * b[6];
	r[1] = a[0] * b[1] + a[1] * b[4] + a[2] * b[7];
	r[2] = a[0] * b[2] + a[1] * b[5] + a[2] * b[8];
	a[0] = r[0];
	a[1] = r[1];
	a[2] = r[2];
	free(r);
}

CVPROJECTCORE_API unsigned char *rotate(unsigned char *img, int width, int height, double degree, unsigned char mode) {
	int nwidth = ceil(abs(width * cos(degree)) + abs(height * sin(degree)));
	int nheight = ceil(abs(height * cos(degree)) + abs(width * sin(degree)));
	unsigned char *newimg = (unsigned char *)malloc(nwidth * nheight * 4 * sizeof(unsigned char));
	memset(newimg, 0, nwidth * nheight * 4 * sizeof(unsigned char));
	double mat1[9] = { 1, 0, 0, 0, -1, 0, -0.5 * (nwidth - 1), 0.5 * (nheight - 1), 1 };
	double mat2[9] = { cos(degree), sin(degree), 0, -sin(degree), cos(degree), 0, 0, 0, 1 };
	double mat3[9] = { 1, 0, 0, 0, -1, 0, 0.5 * (width - 1), 0.5 * (height - 1), 1 };
	for (int i = 0; i < nheight; i++)
		for (int j = 0; j < nwidth; j++) {
			double mat[3] = { j, i, 1 };
			matmul(mat, mat1);
			matmul(mat, mat2);
			matmul(mat, mat3);
			if (OUTSIDE(width, height, mat[1], mat[0])) continue;
			auto oi = mat[1], oj = mat[0];
			if (mode == NEAR)
				*PIXEL(newimg, nwidth, i, j) = *PIXEL(img, width, (int)round(oi), (int)round(oj));
			else {
				auto foi = (int)floor(oi), coi = (int)floor(oi + 1), foj = (int)floor(oj), coj = (int)floor(oj + 1);
				auto p1 = PIXEL(img, width, foi, foj);
				auto p2 = PIXEL(img, width, foi, coj >= width ? foj : coj);
				pixel t1 = { p1->b * (coj - oj) + p2->b * (oj - foj),
					p1->g * (coj - oj) + p2->g * (oj - foj),
					p1->r * (coj - oj) + p2->r * (oj - foj),
					p1->a * (coj - oj) + p2->a * (oj - foj) };
				p1 = PIXEL(img, width, coi >= height ? foi : coi, foj);
				p2 = PIXEL(img, width, coi >= height ? foi : coi, coj >= width ? foj : coj);
				pixel t2 = { p1->b * (coj - oj) + p2->b * (oj - foj),
					p1->g * (coj - oj) + p2->g * (oj - foj),
					p1->r * (coj - oj) + p2->r * (oj - foj),
					p1->a * (coj - oj) + p2->a * (oj - foj) };
				*PIXEL(newimg, nwidth, i, j) = { (unsigned char)(t1.b * (coi - oi) + t2.b * (oi - foi)),
					(unsigned char)(t1.g * (coi - oi) + t2.g * (oi - foi)),
					(unsigned char)(t1.r * (coi - oi) + t2.r * (oi - foi)),
					(unsigned char)(t1.a * (coi - oi) + t2.a * (oi - foi)) };
			}
		}
	return newimg;
}