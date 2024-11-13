#include "PluginSettings.h"
#include <iostream>


extern "C" {
    bool GetNextColor(Color& color, float deltaTime) {
        static float time = 0.0f;
        time += deltaTime;

        color.r = (sin(time) * 0.5f) + 0.5f;
        color.g = (sin(time + 2.0f) * 0.5f) + 0.5f;
        color.b = (sin(time + 4.0f) * 0.5f) + 0.5f;
        color.a = 1.0f;

        return true;
    }
}
