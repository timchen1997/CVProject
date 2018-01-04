// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� CVPROJECTCORE_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// CVPROJECTCORE_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
#ifdef CVPROJECTCORE_EXPORTS
#define CVPROJECTCORE_API  __declspec(dllexport)
#else
#define CVPROJECTCORE_API __declspec(dllimport)
#endif

// �����Ǵ� CVProject.Core.dll ������
class CVPROJECTCORE_API CCVProjectCore {
public:
	CCVProjectCore(void);
	// TODO:  �ڴ�������ķ�����
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