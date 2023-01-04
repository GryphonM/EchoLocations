// DGLDemoProject.cpp : Defines the entry point for the application.
//

#include "Resource.h"
#include "DGL.h"

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
  switch (message)
  {

  default:
    return DefWindowProc(hWnd, message, wParam, lParam);
  }
  return 0;
}
