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

extern "C" CVPROJECTCORE_API int nCVProjectCore;

extern "C" CVPROJECTCORE_API int fnCVProjectCore(void);

extern "C" CVPROJECTCORE_API void modifyImg(char*, int, int);