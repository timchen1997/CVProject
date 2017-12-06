// CVProject.Core.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "CVProject.Core.h"
#include <Windows.h>
#include <GL\glew.h>
#include <GL\GL.h>
#include <GL\GLU.h>


// 这是导出变量的一个示例
CVPROJECTCORE_API int nCVProjectCore=0;

// 这是导出函数的一个示例。
CVPROJECTCORE_API int fnCVProjectCore(void)
{
    return 42;
}

CVPROJECTCORE_API void modifyImg(char *img, int width, int height) 
{
	GLuint imageFBO, imageID, depthTextureID;
	glGenFramebuffersEXT(1, &imageFBO);
	/*
	glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, imageFBO); 
	glGenTextures(1, &imageID);  
	glBindTexture(GL_TEXTURE_2D, imageID);
	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA8, width, height, 0, GL_RGBA, GL_UNSIGNED_BYTE, img);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glFramebufferTexture2DEXT(GL_FRAMEBUFFER_EXT, GL_COLOR_ATTACHMENT0_EXT, GL_TEXTURE_2D, imageID, 0);
	glGenRenderbuffersEXT(1, &depthTextureID);
	glBindRenderbufferEXT(GL_RENDERBUFFER_EXT, depthTextureID);
	glRenderbufferStorageEXT(GL_RENDERBUFFER_EXT, GL_DEPTH_COMPONENT, width, height);
	glFramebufferRenderbufferEXT(GL_FRAMEBUFFER_EXT, GL_DEPTH_ATTACHMENT_EXT, GL_RENDERBUFFER_EXT, depthTextureID);
	glBegin(GL_LINES);
	glVertex2f(0.1, 0.1);
	glVertex2f(0.5, 0.5);
	glEnd();*/
	//glReadPixels(0, 0, width, height, GL_RGBA, GL_UNSIGNED_BYTE, img);
}

// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 CVProject.Core.h
CCVProjectCore::CCVProjectCore()
{
    return;
}
