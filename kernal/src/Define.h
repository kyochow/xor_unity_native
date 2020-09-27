#pragma once
// Unity native plugin API
// Compatible with C99

#if defined(__CYGWIN32__)
    #define WEST_API __declspec(dllexport) __stdcall
#elif defined(WIN32) || defined(_WIN32) || defined(__WIN32__) || defined(_WIN64) || defined(WINAPI_FAMILY)
    #define WEST_API __declspec(dllexport) __stdcall
#elif defined(__MACH__) || defined(__ANDROID__) || defined(__linux__) || defined(__QNX__)
    #define WEST_API
#else
    #define WEST_API
#endif

#define NULL_PTR    0

#if defined(_WIN64)
#define gstrcpy(d, l, s) strcpy_s(d, l, s)
#else
#define gstrcpy(d, l, s) strcpy(d, s)
#endif
