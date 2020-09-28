#pragma once
// Unity native plugin API
// Compatible with C99

#if defined(__CYGWIN32__)
    #define NATIVE_API __declspec(dllexport) __stdcall
#elif defined(WIN32) || defined(_WIN32) || defined(__WIN32__) || defined(_WIN64) || defined(WINAPI_FAMILY)
    #define NATIVE_API __declspec(dllexport) __stdcall
#elif defined(__MACH__) || defined(__ANDROID__) || defined(__linux__) || defined(__QNX__)
    #define NATIVE_API
#else
    #define NATIVE_API
#endif

#define NULL_PTR    0

