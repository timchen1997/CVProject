#pragma once
struct pixel {
	unsigned char b, g, r, a;
};

#define PIXEL(img, width, i, j) ((pixel *)(img) + (width) * (i) + (j))
#define OUTSIDE(width, height, i, j) (((i) < 0) || ((j) < 0) || ((i) > (height - 1)) || ((j) > (width - 1)))
#define KERNELITEM(kernel, size, i, j) (*((kernel) + (size) * (i) + (j)))