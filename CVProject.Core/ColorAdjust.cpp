#include "CVProject.Core.h"
#include "image.h"
#include <algorithm>

using namespace std;

static void RGB2HSL(unsigned char R, unsigned char G, unsigned char B, double &H, double &S, double &L){
	double dR, dG, dB, Max, Min, del_R, del_G, del_B, del_Max;
	dR = R / 255.0;
	dG = G / 255.0;
	dB = B / 255.0;
	Min = min(dR, min(dG, dB));
	Max = max(dR, max(dG, dB));
	del_Max = Max - Min; 
	L = (Max + Min) / 2.0;
	if (del_Max == 0){
		H = 0;
		S = 0;
	}
	else{
		if (L < 0.5)
			S = del_Max / (Max + Min);
		else
			S = del_Max / (2 - Max - Min);
		del_R = (((Max - dR) / 6.0) + (del_Max / 2.0)) / del_Max;
		del_G = (((Max - dG) / 6.0) + (del_Max / 2.0)) / del_Max;
		del_B = (((Max - dB) / 6.0) + (del_Max / 2.0)) / del_Max;
		if (dR == Max)
			H = del_B - del_G;
		else if (dG == Max)
			H = (1.0 / 3.0) + del_R - del_B;
		else if (dB == Max)
			H = (2.0 / 3.0) + del_G - del_R;
		if (H < 0)  H += 1;
		if (H > 1)  H -= 1;
	}
}

static double Hue2RGB(double v1, double v2, double vH){
	if (vH < 0)
		vH += 1;
	if (vH > 1)
		vH -= 1;
	if (6.0 * vH < 1)
		return v1 + (v2 - v1) * 6.0 * vH;
	if (2.0 * vH < 1)
		return v2;
	if (3.0 * vH < 2)
		return v1 + (v2 - v1) * ((2.0 / 3.0) - vH) * 6.0;
	return v1;
}

static void HSL2RGB(double H, double S, double L, unsigned char &R, unsigned char &G, unsigned char &B){
	double dR, dG, dB;
	double var_1, var_2;
	if (S == 0){
		dR = L * 255.0;
		dG = L * 255.0;
		dB = L * 255.0;
	}
	else{
		if (L < 0.5)
			var_2 = L * (1 + S);
		else
			var_2 = (L + S) - (S * L);
		var_1 = 2.0 * L - var_2;
		dR = 255.0 * Hue2RGB(var_1, var_2, H + (1.0 / 3.0));
		dG = 255.0 * Hue2RGB(var_1, var_2, H);
		dB = 255.0 * Hue2RGB(var_1, var_2, H - (1.0 / 3.0));
	}
	R = round(dR);
	G = round(dG);
	B = round(dB);
}

CVPROJECTCORE_API void colorAdjust(unsigned char *img, int width, int height, double hdelta, double sfix, double lfix) {
	for (int i = 0; i < height; i++)
		for (int j = 0; j < width; j++) {
			auto p = PIXEL(img, width, i, j);
			double h, s, l;
			RGB2HSL(p->r, p->g, p->b, h, s, l);
			h += hdelta;
			if (h > 1) h--;
			if (h < 0) h++;
			if (sfix < 0)
				s *= (1 + sfix);
			else if (sfix > 0)
				s = 1 - (1 - s) * (1 - sfix);
			if (lfix < 0)
				l *= (1 + lfix);
			else if (lfix > 0)
				l = 1 - (1 - l) * (1 - lfix);
			HSL2RGB(h, s, l, p->r, p->g, p->b);
		}
}