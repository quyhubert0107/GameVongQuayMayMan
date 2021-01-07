using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VQMMThongBaoGame : MonoBehaviour
{
    private UnityAction _clickOk, _clickCancel;
    private TextMeshProUGUI _txtTitle,_txtThongBao;
    private Button _btnCancel, _btnDongy;
    private void Awake()
    {
        _txtThongBao = transform.Find("BG/txtThongBao").GetComponent<TextMeshProUGUI>();
        _txtTitle = transform.Find("BG/txtTitle").GetComponent<TextMeshProUGUI>();
        _btnCancel = transform.Find("BG/btnCancel").GetComponent<Button>();
        _btnDongy = transform.Find("BG/btnDongY").GetComponent<Button>();
    }

    private void Start()
    {
        _btnCancel.onClick.AddListener(SetCancel);
        _btnDongy.onClick.AddListener(SetDongY);
    }
    
    private void SetCancel()
    {
        if (_clickCancel != null) _clickCancel.Invoke();
        Show(false);
    }
    
    private void SetDongY()
    {
        if (_clickOk != null) _clickOk.Invoke();
        Show(false);
    }
    
    public void ShowThongBao(string title, string content, UnityAction actionOk = null, UnityAction actionCancel = null)
    {
        Show();
        _txtTitle.text = title;
        _txtThongBao.text = content;
        _clickOk = actionOk;
        _clickCancel = actionCancel;
    }

    private void Show(bool val = true)
    {
        gameObject.SetActive(val);
    }
    
}
