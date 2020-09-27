/** 
 *Author:       Kyo Chow
 *Descrp:       Menu菜单
*/

using System.Collections.Generic;
using System.IO;

using UnityEditor;
using UnityEngine;

public class Menu
{
    [MenuItem("Encrypt/Encode", false, 1300)]
    public static void Encode()
    {
        var byteOrigin = File.ReadAllBytes("Assets/Origin/protobuf.lua.txt");
        byte[] cipher= EncryptHelper.EncryptBytes(byteOrigin);
        File.WriteAllBytes("Assets/Encode/protobuf.lua.txt",cipher);
        //想要bundle中的bytes不被额外变成UTF-8的，后缀名要使用.bytes
        File.WriteAllBytes("Assets/Encode/protobuf.lua.bytes",cipher);
        AssetDatabase.Refresh();
    }
    
    [MenuItem("Encrypt/Decode", false, 1301)]
    public static void Decode()
    {
        var byteOrigin = File.ReadAllBytes("Assets/Encode/protobuf.lua.txt");
        byte[] cipher= EncryptHelper.DecryptBytes(byteOrigin);
        File.WriteAllBytes("Assets/Decode/protobuf.lua.txt",cipher);
        
        AssetDatabase.Refresh();
    }
    
    [MenuItem("Encrypt/Build Bundle", false, 1303)]
    private static void BuildBundle()
    {
        AssetBundleBuild b = new AssetBundleBuild();
        b.assetNames = new[] {"Assets/Encode/protobuf.lua.bytes"};
        b.assetBundleName = "lua_all.bytes";
        List<AssetBundleBuild> ab = new List<AssetBundleBuild>();
        ab.Add(b);
        BuildPipeline.BuildAssetBundles(Application.dataPath + "/Ab",ab.ToArray(),BuildAssetBundleOptions.ChunkBasedCompression,BuildTarget.Android);
        AssetDatabase.Refresh();
    }
    
    [MenuItem("Encrypt/Load Bundle", false, 1303)]
    private static void LoadBundle()
    {
        AssetBundle ab = AssetBundle.LoadFromFile(Application.dataPath + "/Ab/lua_all.bytes");
        var lua = ab.LoadAsset<TextAsset>("Assets/Encode/protobuf.lua.bytes").bytes;
        var bts = EncryptHelper.DecryptBytes(lua);
        File.WriteAllBytes("Assets/AbDecode/protobuf.lua.txt",bts);
        ab.Unload(true);
        AssetDatabase.Refresh();
    }

    
    [MenuItem("Encrypt/Encode String", false, 1302)]
    public static void EncodeString()
    {
        string from = "12345张三李四王五7890";
        var to = EncryptHelper.EncryptStr(from);
        var back = EncryptHelper.EncryptStr(to);
        Debug.LogError($"[{from}]  -> [{to}]  -> [{back}]");
    }
    
}
