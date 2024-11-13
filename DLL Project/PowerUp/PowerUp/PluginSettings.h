#pragma once
#include "Color.h"

#ifdef SPRITECOLORCHANGERCPP_EXPORTS
#define SPRITECOLORCHANGERCPP_API __declspec(dllexport)
#else
#define SPRITECOLORCHANGERCPP_API __declspec(dllimport)
#endif

extern "C" {
    SPRITECOLORCHANGERCPP_API bool GetNextColor(Color& color, float deltaTime);
}
