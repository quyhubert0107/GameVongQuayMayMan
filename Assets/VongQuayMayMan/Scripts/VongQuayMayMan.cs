using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class VongQuayMayMan : VQMMSingleton<VongQuayMayMan>
{
    public Entity_question questionData;
    public VQMMMenu menu;
    public VQMMGame game;
    public VQMMHuongDanGame huongDanGame;
    public VQMMDiemCao diemCao;
    public VQMMThongBaoGame thongBaoGame;

    private void Awake()
    {
        SetData();
    }

    private void SetData()
    {
        VQMMData.Instance.ClearData();
        foreach (var dic in questionData.sheets[0].list)
        {
            Question data = new Question();
            data.question = dic.question;
            data.id = dic.id;
            data.level = dic.level;
            data.caseA = dic.casea;
            data.caseB = dic.caseb;
            data.caseC = dic.casec;
            data.caseD = dic.cased;
            data.truecase = dic.truecase;
            VQMMData.Instance.dataVQMMQuestion.Add(data);
        }
        
        // PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint2, 86990500);
        // PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint3, 65890300);
        // PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint4, 5390500);
        // PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint5, 4310520);
        // PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint6, 3390500);
        // PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint7, 3382000);
        // PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint8, 2460800);
        // PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint9, 2390500);
        // PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint10, 1850400);
    }

    public void SetClickDiemCao()
    {
        diemCao.Show();
    }

    private void ShowMenu(bool val = true)
    {
        menu.gameObject.SetActive(val);
    }
    
    public void ShowGame(bool val = true)
    {
        game.gameObject.SetActive(val);
        game.SetInfoStartGame();
    }
    
    public void ShowHuongDanGame(bool val = true)
    {
        huongDanGame.gameObject.SetActive(val);
    }
    
    public void ShowThongBao(string title,string content, UnityAction actionOk = null, UnityAction actionCancel = null)
    {
        thongBaoGame.ShowThongBao(title,content,actionOk,actionCancel);
    }
    
    public void ShowThongBao(string content, UnityAction actionOk = null, UnityAction actionCancel = null)
    {
        thongBaoGame.ShowThongBao(VQMMPRes.Title,content,actionOk,actionCancel);
    }
}
