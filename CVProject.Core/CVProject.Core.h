// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 CVPROJECTCORE_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何其他项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// CVPROJECTCORE_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
#ifdef CVPROJECTCORE_EXPORTS
#define CVPROJECTCORE_API  __declspec(dllexport)
#else
#define CVPROJECTCORE_API __declspec(dllimport)
#endif

// 此类是从 CVProject.Core.dll 导出的
class CVPROJECTCORE_API CCVProjectCore {
public:
	CCVProjectCore(void);
	// TODO:  在此添加您的方法。
};

extern "C" CVPROJECTCORE_API void binarizeImg(unsigned char *, int, int, bool, unsigned char, unsigned char, bool, unsigned char, unsigned char, bool, unsigned char, unsigned char);

extern "C" CVPROJECTCORE_API void binarizeImgOtsu(unsigned char *, int, int);

extern "C" CVPROJECTCORE_API void toGrayScale(unsigned char *, int, int, unsigned char);

extern "C" CVPROJECTCORE_API void smooth(unsigned char *, int, int, double *, int);

extern "C" CVPROJECTCORE_API void smoothMedian(unsigned char *, int, int, int);

extern "C" CVPROJECTCORE_API unsigned char *resize(unsigned char *, int, int, int, int, unsigned char);

extern "C" CVPROJECTCORE_API unsigned char *rotate(unsigned char *, int, int, double, unsigned char);

extern "C" CVPROJECTCORE_API void colorAdjust(unsigned char *, int, int, double, double, double);

extern "C" CVPROJECTCORE_API void sobel(unsigned char *, int, int, int);

extern "C" CVPROJECTCORE_API void laplacian(unsigned char *, int, int, int);

extern "C" CVPROJECTCORE_API void canny(unsigned char *, int, int, int, int, int);

extern "C" CVPROJECTCORE_API void ArithmeticOper(unsigned char *, int, int, unsigned char *, int, int, double, double, int);

extern "C" CVPROJECTCORE_API int houghLine(unsigned char *, int, int, int, int*);

extern "C" CVPROJECTCORE_API int houghCircle(unsigned char *, int, int, int, int, int,int*);

extern "C" CVPROJECTCORE_API void histogramBalance(unsigned char *, int, int);

extern "C" CVPROJECTCORE_API void contrastLinear(unsigned char *, int, int, unsigned char, unsigned char, unsigned char, unsigned char);

extern "C" CVPROJECTCORE_API void contrastLog(unsigned char *, int, int, double);

extern "C" CVPROJECTCORE_API void contrastExp(unsigned char *, int, int, double);

extern "C" CVPROJECTCORE_API void dilate(unsigned char *, int, int, unsigned char *);

extern "C" CVPROJECTCORE_API void erode(unsigned char *, int, int, unsigned char *);

extern "C" CVPROJECTCORE_API void open(unsigned char *, int, int, unsigned char *);

extern "C" CVPROJECTCORE_API void close(unsigned char *, int, int, unsigned char *);

extern "C" CVPROJECTCORE_API void thin(unsigned char *, int, int, unsigned char *);

extern "C" CVPROJECTCORE_API void thick(unsigned char *, int, int, unsigned char *);

extern "C" CVPROJECTCORE_API void skeleton(unsigned char *, int, int, unsigned char *);

extern "C" CVPROJECTCORE_API void distanceTrans(unsigned char *, int, int);

extern "C" CVPROJECTCORE_API void skeletonRebuild(unsigned char *, int, int, unsigned char *);

extern "C" CVPROJECTCORE_API void morphologicalReconstruct(unsigned char *, unsigned char *, int, int, unsigned char*);

extern "C" CVPROJECTCORE_API void watershed(unsigned char *, int, int);