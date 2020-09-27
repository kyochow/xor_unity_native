using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text _text;
    public void OnClick()
    {
        string from = "12345张三李四王五7890";
        var to = EncryptHelper.EncryptStr(from);
        var back = EncryptHelper.EncryptStr(to);
        _text.text = $"[{from}]  \n [{to}]  \n [{back}]";
    }
}
