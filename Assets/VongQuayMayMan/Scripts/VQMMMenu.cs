using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VQMMMenu : MonoBehaviour
{
    private Button _btnStartGame, _btnHuongDanGame, _btnQuitGame, _btnDiemCao;
    private void Awake()
    {
        _btnStartGame = transform.Find("GroupButton/btnStartGame").GetComponent<Button>();
        _btnDiemCao = transform.Find("GroupButton/btnDiemCao").GetComponent<Button>();
        _btnHuongDanGame = transform.Find("GroupButton/btnHuongDanGame").GetComponent<Button>();
        _btnQuitGame = transform.Find("GroupButton/btnQuitGame").GetComponent<Button>();
    }

    private void Start()
    {
        _btnStartGame.onClick.AddListener(SetStartGame);
        _btnHuongDanGame.onClick.AddListener(SetHuongDanGame);
        _btnQuitGame.onClick.AddListener(SetQuitGame);
        _btnDiemCao.onClick.AddListener(SetClickDiemCao);
    }
    
    private void SetStartGame()
    {
        VQMMAudio.Instance.LoadAudioStartGame();
        VongQuayMayMan.Instance.ShowGame();
    }
    
    private void SetHuongDanGame()
    {
        VongQuayMayMan.Instance.ShowHuongDanGame();
    }
    
    public void SetClickDiemCao()
    {
        VongQuayMayMan.Instance.diemCao.Show();
    }
    
    private void SetQuitGame()
    {
        Application.Quit();
    }
}
