// CVProject.Core.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "CVProject.Core.h"



// 这是导出变量的一个示例
CVPROJECTCORE_API int nCVProjectCore=0;

// 这是导出函数的一个示例。
CVPROJECTCORE_API int fnCVProjectCore(void)
{
    return 42;
}

CVPROJECTCORE_API void modifyImg(char *img, int width, int height) 
{

	//glReadPixels(0, 0, width, height, GL_RGBA, GL_UNSIGNED_BYTE, img);
}

// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 CVProject.Core.h
CCVProjectCore::CCVProjectCore()
{
    return;
}
