// CVProject.Core.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"
#include "CVProject.Core.h"



// ���ǵ���������һ��ʾ��
CVPROJECTCORE_API int nCVProjectCore=0;

// ���ǵ���������һ��ʾ����
CVPROJECTCORE_API int fnCVProjectCore(void)
{
    return 42;
}

CVPROJECTCORE_API void modifyImg(char *img, int width, int height) 
{

	//glReadPixels(0, 0, width, height, GL_RGBA, GL_UNSIGNED_BYTE, img);
}

// �����ѵ�����Ĺ��캯����
// �й��ඨ�����Ϣ������� CVProject.Core.h
CCVProjectCore::CCVProjectCore()
{
    return;
}
