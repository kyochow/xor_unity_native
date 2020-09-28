using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text _text;
    public void OnClick()
    {
        LoadBundle(); 
    }
    
    
    private void LoadBundle()
    {
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/lua_all.bytes");
        var lua = ab.LoadAsset<TextAsset>("Assets/Encode/protobuf.lua.bytes").bytes;
        var bts = EncryptHelper.DecryptBytes(lua);
        File.WriteAllBytes( Application.persistentDataPath + "/protobuf.lua.txt",bts);
        ab.Unload(true);

        _text.text = File.ReadAllText(Application.persistentDataPath + "/protobuf.lua.txt");

    }
}
