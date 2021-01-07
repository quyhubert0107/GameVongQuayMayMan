using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VQMMDiemCao : MonoBehaviour
{
    private TextMeshProUGUI _txtDiemCao;
    private void Awake()
    {
        _txtDiemCao = transform.Find("txtDiemCao").GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        SetInfo();
    }

    private void SetInfo()
    {
        string info = "";

        if (PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint1) > 0)
        {
            info += "HẠNG 1 : " + AgentLV.GetColorTextRed(GetPoint(VQMMKeySaverLocal.Maxpoint1));
        }
        if (PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint2) > 0)
        {
            info += "\n" + "HẠNG 2 : " + AgentLV.GetColorTextOrange(GetPoint(VQMMKeySaverLocal.Maxpoint2));
        }
        if (PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint3) > 0)
        {
            info += "\n" + "HẠNG 3 : " + AgentLV.GetColorTextXanhLaCay(GetPoint(VQMMKeySaverLocal.Maxpoint3));
        }
        if (PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint4) > 0)
        {
            info += "\n" +"HẠNG 4 : " + GetPoint(VQMMKeySaverLocal.Maxpoint4);
        }
        if (PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint5) > 0)
        {
            info += "\n" +"HẠNG 5 : " + GetPoint(VQMMKeySaverLocal.Maxpoint5);
        }
        if (PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint6) > 0)
        {
            info += "\n" +"HẠNG 6 : " + GetPoint(VQMMKeySaverLocal.Maxpoint6);
        }
        if (PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint7) > 0)
        {
            info += "\n" +"HẠNG 7 : " + GetPoint(VQMMKeySaverLocal.Maxpoint7);
        }
        if (PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint8) > 0)
        {
            info += "\n" +"HẠNG 8 : " + GetPoint(VQMMKeySaverLocal.Maxpoint8);
        }
        if (PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint9) > 0)
        {
            info += "\n" +"HẠNG 9 : " + GetPoint(VQMMKeySaverLocal.Maxpoint9);
        }
        if (PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint10) > 0)
        {
            info += "\n" + "HẠNG 10 : " + GetPoint(VQMMKeySaverLocal.Maxpoint10);
        }

        _txtDiemCao.text = info;
    }

    private string GetPoint(string key)
    {
         return VQMMData.ShowPoint(PlayerPrefs.GetInt(key));
    }

    public void Show(bool val = true)
    {
        gameObject.SetActive(val);
    }
    
}
