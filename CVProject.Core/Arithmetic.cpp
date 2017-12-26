#include "CVProject.Core.h"
#include "image.h"
#include <algorithm>

CVPROJECTCORE_API void ArithmeticOper(unsigned char *imgA, int widthA, int heightA, unsigned char *imgB, int widthB, int heightB, double ratioA, double ratioB, int oper) {
	int width = std::min(widthA, widthB);
	int height = std::min(heightA, heightB);
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto pa = PIXEL(imgA, widthA, i, j);
			auto pb = PIXEL(imgB, widthB, i, j);
			int r, g, b;
			if (oper == 0) {
				r = pa->r * ratioA + pb->r * ratioB;
				g = pa->g * ratioA + pb->g * ratioB;
				b = pa->b * ratioA + pb->b * ratioB;
			}
			else {
				r = pa->r * ratioA * pb->r * ratioB;
				g = pa->g * ratioA * pb->g * ratioB;
				b = pa->b * ratioA * pb->b * ratioB;
			}
			r = std::min(255, r);
			g = std::min(255, g);
			b = std::min(255, b);
			r = std::max(0, r);
			g = std::max(0, g);
			b = std::max(0, b);
			pa->r = r;
			pa->g = g;
			pa->b = b;
		}
}