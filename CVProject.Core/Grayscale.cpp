#include "CVProject.Core.h"
#include "image.h"
#include <cassert>

enum GrayMode {AUTO = 0, RED, GREEN, BLUE};

CVPROJECTCORE_API void toGrayScale(unsigned char* img, int width, int height, unsigned char grayMode) {
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			unsigned char t;
			switch (grayMode) {
			case AUTO:
				t = 0.299 * p->r + 0.587 * p->g + 0.114 * p->b;
				break;
			case RED:
				t = p->r;
				break;
			case GREEN:
				t = p->g;
				break;
			case BLUE:
				t = p->b;
				break;
			default:
				assert(0);
			}
			p->r = p->g = p->b = t;
		}
}