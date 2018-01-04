#include "CVProject.Core.h"
#include "image.h"
#include <algorithm>
#include <cstring>
#include <vector>

template <typename T>
struct mystack {
	T data[100000000];
	int topptr;

	mystack() :topptr(0) {
		memset(data, 0, sizeof(0));
	}

	void push(T item) {
		data[topptr++] = item;
	}

	void pop() {
		topptr--;
	}

	T top() {
		return data[topptr - 1];
	}

	bool empty() {
		return topptr == 0;
	}
};

CVPROJECTCORE_API void dilate(unsigned char *img, int width, int height, unsigned char *kernel) {
	unsigned char *newimg = (unsigned char *)malloc(sizeof(unsigned char) * width * height * 4);
	memset(newimg, 0, sizeof(unsigned char) * width * height * 4);
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(newimg, width, i, j);
			unsigned char maxn = 0;
			for (int a = -3; a <= 3; a++)
				for (int b = -3; b <= 3; b++) {
					int ni = i + a, nj = j + b;
					if (OUTSIDE(width, height, ni, nj)) continue;
					if (!KERNELITEM(kernel, 7, a + 3, b + 3)) continue;
					maxn = std::max(maxn, PIXEL(img, width, ni, nj)->r);
				}
			p->r = p->g = p->b = maxn;
			p->a = PIXEL(img, width, i, j)->a;
		}
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++)
			*PIXEL(img, width, i, j) = *PIXEL(newimg, width, i, j);
	free(newimg);
}

CVPROJECTCORE_API void erode(unsigned char *img, int width, int height, unsigned char *kernel) {
	unsigned char *newimg = (unsigned char *)malloc(sizeof(unsigned char) * width * height * 4);
	memset(newimg, 0, sizeof(unsigned char) * width * height * 4);
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(newimg, width, i, j);
			unsigned char minn = 255;
			for (int a = -3; a <= 3; a++)
				for (int b = -3; b <= 3; b++) {
					int ni = i + a, nj = j + b;
					if (OUTSIDE(width, height, ni, nj)) continue;
					if (!KERNELITEM(kernel, 7, a + 3, b + 3)) continue;
					minn = std::min(minn, PIXEL(img, width, ni, nj)->r);
				}
			p->r = p->g = p->b = minn;
			p->a = PIXEL(img, width, i, j)->a;
		}
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++)
			*PIXEL(img, width, i, j) = *PIXEL(newimg, width, i, j);
	free(newimg);
}

CVPROJECTCORE_API void open(unsigned char *img, int width, int height, unsigned char *kernel) {
	erode(img, width, height, kernel);
	dilate(img, width, height, kernel);
}

CVPROJECTCORE_API void close(unsigned char *img, int width, int height, unsigned char *kernel) {
	dilate(img, width, height, kernel);
	erode(img, width, height, kernel);	
}

static unsigned char *hitnothit(unsigned char *img, int width, int height, unsigned char *kernel, int size){
	unsigned char *newimg = (unsigned char *)malloc(sizeof(unsigned char) * width * height * 4);
	memset(newimg, 0, sizeof(unsigned char) * width * height * 4);
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(newimg, width, i, j);
			bool hit = true;
			for (int a = -size / 2; a <= size / 2; a++)
				for (int b = -size / 2; b <= size / 2; b++) {
					int ni = i + a, nj = j + b;
					if (OUTSIDE(width, height, ni, nj)) {
						hit = false;
						goto next;
					}
					if (KERNELITEM(kernel, size, a + size / 2, b + size / 2) == 128) continue;
					if (KERNELITEM(kernel, size, a + size / 2, b + size / 2) != PIXEL(img, width, ni, nj)->r) {
						hit = false;
						goto next;
					}
				}
		next:
			p->r = p->g = p->b = hit ? 255 : 0;
		}
	return newimg;
}

static unsigned char *rotate(unsigned char *kernel) {
	unsigned char *r = (unsigned char *)malloc(9 * sizeof(unsigned char));
	r[0] = kernel[3];
	r[1] = kernel[0];
	r[2] = kernel[1];
	r[3] = kernel[6];
	r[4] = kernel[4];
	r[5] = kernel[2];
	r[6] = kernel[7];
	r[7] = kernel[8];
	r[8] = kernel[5];
	return r;
}

static void or(unsigned char* a, unsigned char *b, int width, int height) {
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(a, width, i, j);
			unsigned char val = std::max(p->r, PIXEL(b, width, i, j)->r);
			p->r = p->g = p->b = val;
		}
}

static void and(unsigned char* a, unsigned char *b, int width, int height) {
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(a, width, i, j);
			unsigned char val = std::min(p->r, PIXEL(b, width, i, j)->r);
			p->r = p->g = p->b = val;
		}
}

static bool equal(unsigned char *a, unsigned char *b, int width, int height) {
	if (a == nullptr || b == nullptr) return false;
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++)
			if (PIXEL(a, width, i, j)->r != PIXEL(b, width, i, j)->r)
				return false;
	return true;
}

static bool isEmpty(unsigned char *img, int width, int height) {
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++)
			if (PIXEL(img, width, i, j)->r == 255)
				return false;
	return true;
}

static void minus(unsigned char *a, unsigned char *b, int width, int height) {
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto pa = PIXEL(a, width, i, j), pb = PIXEL(b, width, i, j);
			if (pa->r == 255 && pb->r == 0)
				pa->r = pa->g = pa->b = 255;
			else
				pa->r = pa->g = pa->b = 0;
		}
}

static void reverse(unsigned char *img, int width, int height) {
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			p->r = p->g = p->b = 255 - p->r;
		}
}

static unsigned char *duplicate(unsigned char *img, int width, int height) {
	unsigned char *r = (unsigned char *)malloc(sizeof(unsigned char) * width * height * 4);
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++)
			*PIXEL(r, width, i, j) = *PIXEL(img, width, i, j);
	return r;
}

CVPROJECTCORE_API void thick(unsigned char *img, int width, int height, unsigned char *kernel) {
	unsigned char *t = kernel;
	unsigned char *timg = duplicate(img, width, height);
	for (int i = 0; i < 8; i++) {
		auto newimg = hitnothit(img, width, height, t, 3);
		or(timg, newimg, width, height);		
		auto nt = rotate(t);
		if (i) free(t);
		t = nt;
		free(newimg);
	}
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++)
			*PIXEL(img, width, i, j) = *PIXEL(timg, width, i, j);
	free(timg);
}

static unsigned char *_thin(unsigned char *img, int width, int height, unsigned char *kernel) {
	unsigned char *t = kernel;
	unsigned char *timg = duplicate(img, width, height);
	for (int i = 0; i < 8; i++) {
		auto newimg = hitnothit(timg, width, height, t, 3);
		reverse(newimg, width, height);
		and(timg, newimg, width, height);
		auto nt = rotate(t);
		if (i) free(t);
		t = nt;
		free(newimg);
	}
	return timg;
}

CVPROJECTCORE_API void thin(unsigned char *img, int width, int height, unsigned char *kernel) {
	unsigned char *t;
begin:
	t = _thin(img, width, height, kernel);
	if (!equal(t, img, width, height)) {
		for (int i = 0; i < height; i++)
			for (int j = 0; j < height; j++)
				*PIXEL(img, width, i, j) = *PIXEL(t, width, i, j);
		free(t);
		goto begin;
	}
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++)
			*PIXEL(img, width, i, j) = *PIXEL(t, width, i, j);
}

CVPROJECTCORE_API void skeleton(unsigned char *img, int width, int height, unsigned char *kernel) {
	int k = 0;
	auto timg = duplicate(img, width, height);
	auto ans = (unsigned char *)malloc(sizeof(unsigned char) * width * height * 4);
	memset(ans, 0, sizeof(unsigned char) * height * width * 4);
	for (; !isEmpty(timg, width, height); k++) {
		erode(timg, width, height, kernel);
	}
	free(timg);
	for (int i = 0; i < k; i++) {
		timg = duplicate(img, width, height);
		for (int j = 0; j < i; j++)
			erode(timg, width, height, kernel);
		auto t2img = duplicate(timg, width, height);
		open(t2img, width, height, kernel);
		minus(timg, t2img, width, height);
		or(ans, timg, width, height);
		free(timg);
		free(t2img);
	}
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p1 = PIXEL(img, width, i, j), p2 = PIXEL(ans, width, i, j);
			p1->r = p2->r;
			p1->g = p2->g;
			p1->b = p2->b;
		}
	free(ans);
}

CVPROJECTCORE_API void skeletonRebuild(unsigned char *img, int width, int height, unsigned char *kernel) {
	int k = 0;
	std::vector<unsigned char *> ska;
	auto timg = duplicate(img, width, height);
	auto ans = (unsigned char *)malloc(sizeof(unsigned char) * width * height * 4);
	memset(ans, 0, sizeof(unsigned char) * height * width * 4);
	for (; !isEmpty(timg, width, height); k++) {
		erode(timg, width, height, kernel);
	}
	free(timg);
	for (int i = 0; i < k; i++) {
		timg = duplicate(img, width, height);
		for (int j = 0; j < i; j++)
			erode(timg, width, height, kernel);
		auto t2img = duplicate(timg, width, height);
		open(t2img, width, height, kernel);
		minus(timg, t2img, width, height);
		//or(ans, timg, width, height);
		ska.push_back(timg);
		free(t2img);
	}
	for (int i = 0; i < k; i++) {
		timg = ska[i];
		for (int j = 0; j < i; j++)
			dilate(timg, width, height, kernel);
		or (ans, timg, width, height);
		free(timg);
	}
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p1 = PIXEL(img, width, i, j), p2 = PIXEL(ans, width, i, j);
			p1->r = p2->r;
			p1->g = p2->g;
			p1->b = p2->b;
		}
	free(ans);
}

static inline int sqr(int a) {
	return a * a;
}

CVPROJECTCORE_API void distanceTrans(unsigned char *img, int width, int height) {
	auto timg = (signedPixel *)malloc(sizeof(signedPixel) * width * height);
	int maxd = 0;
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			if (PIXEL(img, width, i, j)->r != 255) continue;
			int mind = 2147483647;
			for (int a = 0; a < height; a++)
				for (int b = 0; b < width; b++) {
					if (PIXEL(img, width, a, b)->r != 0) continue;
					int d = sqr(a - i) + sqr(b - j);
					mind = std::min(d, mind);
				}
			auto p = SIGNEDPIXEL(timg, width, i, j);
			p->r = mind;
			maxd = std::max(mind, maxd);
		}
	double td = sqrt(maxd);
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			p->r = p->g = p->b = sqrt(SIGNEDPIXEL(timg, width, i, j)->r) / td * 255;
		}
	free(timg);
}

CVPROJECTCORE_API void morphologicalReconstruct(unsigned char *a, unsigned char *b, int width, int height, unsigned char* kernel) {
	unsigned char *timg = duplicate(b, width, height), *backup = nullptr;
	do {
		if (backup) free(backup);
		backup = duplicate(timg, width, height);
		dilate(timg, width, height, kernel);
		and (timg, a, width, height);
	} while (!equal(backup, timg, width, height));
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p1 = PIXEL(a, width, i, j), p2 = PIXEL(timg, width, i, j);
			p1->r = p2->r;
			p1->g = p2->g;
			p1->b = p2->b;
		}
	free(timg);
	free(backup);
}

const int dx[8] = { 1, 1, 0, -1, -1, -1, 0, 1 };
const int dy[8] = { 0, 1, 1, 1, 0, -1, -1, -1 };

static bool hasneighbour(int x, int y, int *mark, int width, int height, int val) {
	for (int i = 0; i < 8; i++) {
		int nx = x + dx[i], ny = y + dy[i];
		if (OUTSIDE(width, height, nx, ny)) continue;
		if (mark[nx * width + ny] != 0 && mark[nx * width + ny] != 2147483667 && mark[nx * width + ny] != val)
			return true;
	}
	return false;
}

static const int step = 20;

static void expand(mystack<std::pair<int, int>> *s, int x, int y, int val, unsigned char *img, int *mark, bool *visited, int width, int height, int level) {
	while (!s->empty()) {
		auto point = s->top();
		s->pop();
		int x = point.first, y = point.second;
		visited[x * width + y] = true;
		for (int i = 0; i < 8; i++) {
			int nx = x + dx[i], ny = y + dy[i];
			if (OUTSIDE(width, height, nx, ny)) continue;
			auto p = PIXEL(img, width, nx, ny);
			if (visited[nx * width + ny])
				continue;
			if (!mark[nx * width + ny] && p->r >= level && p->r < level + step) {
				if (hasneighbour(nx, ny, mark, width, height, val)) {
					mark[nx * width + ny] = 2147483647;
					p->r = p->g = p->b = 255;
					continue;
				}
				mark[nx * width + ny] = val;
				s->push(std::make_pair(nx, ny));
			}
		}
	}
}

CVPROJECTCORE_API void watershed(unsigned char *img, int width, int height) {
	int *mark = (int *)malloc(sizeof(int) * width * height);
	bool *visited = (bool *)malloc(sizeof(bool) * width * height);
	memset(mark, 0, sizeof(int) * width * height);	
	int areas = 0;
	mystack<std::pair<int, int>> *s;
	s = new mystack<std::pair<int, int>>();
	int l = 0;
	while (l < 255) {
		memset(visited, 0, sizeof(bool) * width * height);
		for (int i = 0; i < height; i++)
			for (int j = 0; j < width; j++)
				if (!visited[i * width + j] && mark[i * width + j]) {
					s->push(std::make_pair(i, j));
					expand(s, i, j, mark[i * width + j], img, mark, visited, width, height, l);
				}
		for (int i = 0; i < height; i++)
			for (int j = 0; j < width; j++) {
				auto p = PIXEL(img, width, i, j);
				if (!visited[i * width + j] && p->r >= l && p->r < l + step) {
					mark[i * width + j] = ++areas;
					s->push(std::make_pair(i, j));
					expand(s, i, j, areas, img, mark, visited, width, height, l);
				}
			}
		l += step;
	}
	free(mark);
	free(visited);
	delete s;
}