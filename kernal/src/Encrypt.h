#include <stdio.h>
#include<string.h>
#include "Define.h"

#ifdef __cplusplus
extern "C"
{
#endif

    //Encrypt
    void NATIVE_API EncodeNoGC(char* params, int paramsLength);
    //Decrypt
    void NATIVE_API DecodeNoGC(char* params, int paramsLength);
    //The key , can be set from outside
    char KEY[] = "I am proud of being Chinese";
#ifdef __cplusplus
}
#endif
