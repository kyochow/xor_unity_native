/** 
 *Author:       Kyo Chow
 *Descrp:       与库对应
*/

using System;
using System.Runtime.InteropServices;
using System.Text;

public class Encrypt
{
#if UNITY_IOS && !UNITY_EDITOR
	const string ENCRYPT_DLL = "__Internal";
#else
    const string ENCRYPT_DLL = "kernal";
#endif
    [DllImport(ENCRYPT_DLL, EntryPoint = "EncodeNoGC", CallingConvention = CallingConvention.Cdecl)]
    public static extern void EncodeNoGC(byte[] aData, int aLength);
    
    [DllImport(ENCRYPT_DLL, EntryPoint = "DecodeNoGC", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DecodeNoGC(byte[] aData, int aLength);
}

public class EncryptHelper
{
    public static byte[] EncryptBytes(byte[] aCodeStr)
    {
        Encrypt.EncodeNoGC(aCodeStr, aCodeStr.Length);
        return aCodeStr;
    }
    public static byte[] DecryptBytes(byte[] aEncodedCodeStr)
    {
        Encrypt.DecodeNoGC(aEncodedCodeStr, aEncodedCodeStr.Length);
        return aEncodedCodeStr;
    }
    
    public static string EncryptStr(string str)
    {
        var bytes = Encoding.Unicode.GetBytes(str);
        return Encoding.Unicode.GetString(EncryptBytes(bytes));
    }

    public static string DecryptStr(string str)
    {
        var bytes = Encoding.Unicode.GetBytes(str);
        return Encoding.Unicode.GetString(DecryptBytes(bytes));
    }
}
