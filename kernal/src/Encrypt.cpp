#include <stdio.h>
#include<string.h>
#include "Encrypt.h"

#ifdef __cplusplus
extern "C"
{
#endif
    void WEST_API EncodeNoGC(char* params, int paramsLength)
    {
        int length = strlen(KEY);
        for (int i = 0; i < paramsLength; ++i) {
            params[i] = params[i] ^ KEY[i%length];
        }
    }

    void WEST_API DecodeNoGC(char* params, int paramsLength)
    {
        EncodeNoGC(params,paramsLength);
    }
#ifdef __cplusplus
}
#endif
