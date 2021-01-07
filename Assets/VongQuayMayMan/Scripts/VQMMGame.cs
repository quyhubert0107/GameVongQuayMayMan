using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class VQMMGame : MonoBehaviour
{
    private Toggle _tgdapanA, _tgdapanB, _tgdapanC, _tgdapanD;
    private TextMeshProUGUI _txtQuestion, _txtDapAnA, _txtDapAnB, _txtDapAnC, _txtDapAnD, _txtTime;
    private Button _btnExit, _btnSpin;
    private Image _huDapAnA, _huDapAnB, _huDapAnC, _huDapAnD;
    private TextMeshProUGUI _txtDiemHienTai, _txtDiemCaoNhat;
    private Transform _groupTgDapAn;
    private Image _imgVongQuay;
    
    private void Awake()
    {
        _groupTgDapAn = transform.Find("GroupTgDapAn");
        _txtQuestion = transform.Find("imgQuestion/txtQuestion").GetComponent<TextMeshProUGUI>();
        _txtDapAnA = transform.Find("GroupTgDapAn/DapAnA/Label").GetComponent<TextMeshProUGUI>();
        _txtDapAnB = transform.Find("GroupTgDapAn/DapAnB/Label").GetComponent<TextMeshProUGUI>();
        _txtDapAnC = transform.Find("GroupTgDapAn/DapAnC/Label").GetComponent<TextMeshProUGUI>();
        _txtDapAnD = transform.Find("GroupTgDapAn/DapAnD/Label").GetComponent<TextMeshProUGUI>();
        _tgdapanA = transform.Find("GroupTgDapAn/DapAnA").GetComponent<Toggle>();
        _tgdapanB = transform.Find("GroupTgDapAn/DapAnB").GetComponent<Toggle>();
        _tgdapanC = transform.Find("GroupTgDapAn/DapAnC").GetComponent<Toggle>();
        _tgdapanD = transform.Find("GroupTgDapAn/DapAnD").GetComponent<Toggle>();
        _txtTime = transform.Find("imgTime/txtTime").GetComponent<TextMeshProUGUI>();
        _btnSpin = transform.Find("VongQuayMayMan/btnSpin").GetComponent<Button>();
        _btnExit = transform.Find("btnExit").GetComponent<Button>();
        _imgVongQuay = transform.Find("VongQuayMayMan/vongquay").GetComponent<Image>();
        _txtDiemHienTai = transform.Find("lbDiemHienTai/txtDiemHienTai").GetComponent<TextMeshProUGUI>();
        _txtDiemCaoNhat = transform.Find("lbDiemCaoNhat/txtDiemCaoNhat").GetComponent<TextMeshProUGUI>();
        _huDapAnA = transform.Find("GroupTgDapAn/DapAnA/HUDapAn").GetComponent<Image>();
        _huDapAnB = transform.Find("GroupTgDapAn/DapAnB/HUDapAn").GetComponent<Image>();
        _huDapAnC = transform.Find("GroupTgDapAn/DapAnC/HUDapAn").GetComponent<Image>();
        _huDapAnD = transform.Find("GroupTgDapAn/DapAnD/HUDapAn").GetComponent<Image>();
    }
    
    private const int PointX2 = 1;
    private const int PointX3 = 2;
    private const int PointX5 = 3;
    private const int PointChiadoi = 4;
    private const int PointMatdiem = 5;
    private const int Point10 = 6;
    private const int Point50 = 7;
    private const int Point100 = 8;
    private const int Point200 = 9;
    private const int Point500 = 10;
    private const int Point10000 = 11;
    private const int Point100000 = 12;

    private int phanTramX2 = 15;
    private int phanTramX3 = 10;
    private int phanTramX5 = 5;
    private int phanTramChiaDoi = 15;
    private int phanTramMatDiem = 5;
    private int phanTram10 = 50;
    private int phanTram50 = 40;
    private int phanTram100 = 30;
    private int phanTram200 = 20;
    private int phanTram500 = 15;
    private int phanTram10000 = 10;
    private int phanTram100000 = 5;
    private double DapAnDung { get; set; }
    private double DapAnChon { get; set; }
    
    
    private Question _data = new Question();
    

    private void Start()
    {
        _btnExit.onClick.AddListener(SetExit);
        _btnSpin.onClick.AddListener(SetSpin);
        
        _tgdapanA.onValueChanged.AddListener((arg0 =>
        {
            if (_tgdapanA.isOn) SetChonDapAn(1);
        } ));
        
        _tgdapanB.onValueChanged.AddListener((arg0 =>
        {
            if (_tgdapanB.isOn) SetChonDapAn(2);
        } ));
        
        _tgdapanC.onValueChanged.AddListener((arg0 =>
        {
            if (_tgdapanC.isOn) SetChonDapAn(3);
        } ));
        
        _tgdapanD.onValueChanged.AddListener((arg0 =>
        {
            if (_tgdapanD.isOn) SetChonDapAn(4);
        } ));
    }
    
    private void SetChonDapAn(int index)
    {
        DapAnChon = index;
    }

    private void InteractableDapAn(bool val = true)
    {
        _tgdapanA.interactable = val;
        _tgdapanB.interactable = val;
        _tgdapanC.interactable = val;
        _tgdapanD.interactable = val;
    }

    private void SetExit()
    {
        VongQuayMayMan.Instance.ShowThongBao(VQMMPRes.ThoatGame + VQMMData.Instance.PointHienTai + "\n" + VQMMPRes.XacNhanThoat,
            delegate
            {
                Show(false);
                VQMMAudio.Instance.LoadAudioStop();
            });
    }

    private void SetSpin()
    {
        SetAnimSpin(GetPoint());
    }
    
    public void SetInfoStartGame()
    {
        Debug.LogError("đang RESET");
        ResetDataGame();
        SetInfo();
    }

    private void InteractableSpin(bool val = true)
    {
        _btnSpin.interactable = val;
        IsSpin = val;
        InteractableDapAn(!val);
    }

    private bool IsSpin { get; set; }
    
    private void SetInfo()
    {
        StopAllCoroutines();
        _data = VQMMData.Instance.GetDataVqmmQuestionRandom();
        SetText();
        StartTime();
        ResetChonDapAn();
        SetDiemCaoNhat();
    }
    
    private void SetText()
    {
        _txtQuestion.text = _data.question;
        _txtDapAnA.text = _data.caseA;
        _txtDapAnB.text = _data.caseB;
        _txtDapAnC.text = _data.caseC;
        _txtDapAnD.text = _data.caseD;
        DapAnDung = _data.truecase;
        Debug.LogError("DapAnDung = " + DapAnDung);
    }
    
    private IEnumerator DemTime(int time)
    {
        int t = time;
        while (t > 0)
        {
            t -= 1;

            if (t < 5) _txtTime.color = Color.red;
            else _txtTime.color = Color.white;
            yield return new WaitForSeconds(1F);
            _txtTime.text = t.ToString();
            if (t <= 0) StartCoroutine(CheckDapAn());
        }
    }
    
    private IEnumerator CheckDapAn()
    {
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (DapAnChon == DapAnDung)
        {
            // chọn đúng
            SetHieuUngDapAn(DapAnDung);
            yield return new WaitForSeconds(2F);
            OffHieuUng();
            InteractableSpin();
        }
        else
        {
            // thua cuộc
            string content = "";
            if (VQMMData.Instance.PointHienTai < PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint1)) content = VQMMPRes.ThongBaoThua;
            else content = VQMMPRes.XacLapKiLucMoi;
            
            VongQuayMayMan.Instance.ShowThongBao(content + AgentLV.GetColorTextRed(VQMMData.Instance.PointHienTai) + "\n" + VQMMPRes.ChoiLai,
                delegate { SetInfoStartGame(); }, delegate
                {
                    Show(false);
                });
            SavePointCao();
            yield return new WaitForSeconds(0.1F);
            StopAllCoroutines();
        }
    }


    private void SavePointCao()
    {
        if(VQMMData.Instance.PointHienTai > PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint1))
            PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint1,VQMMData.Instance.PointHienTai);
        else if(VQMMData.Instance.PointHienTai > PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint2))
            PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint2,VQMMData.Instance.PointHienTai);
        else if(VQMMData.Instance.PointHienTai > PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint3))
            PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint3,VQMMData.Instance.PointHienTai);
        else if(VQMMData.Instance.PointHienTai > PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint4))
            PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint4,VQMMData.Instance.PointHienTai);
        else if(VQMMData.Instance.PointHienTai > PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint5))
            PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint5,VQMMData.Instance.PointHienTai);
        else if(VQMMData.Instance.PointHienTai > PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint6))
            PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint6,VQMMData.Instance.PointHienTai);
        else if(VQMMData.Instance.PointHienTai > PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint7))
            PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint7,VQMMData.Instance.PointHienTai);
        else if(VQMMData.Instance.PointHienTai > PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint8))
            PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint8,VQMMData.Instance.PointHienTai);
        else if(VQMMData.Instance.PointHienTai > PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint9))
            PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint9,VQMMData.Instance.PointHienTai);
        else if(VQMMData.Instance.PointHienTai > PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint10))
            PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint10,VQMMData.Instance.PointHienTai);
    }
    
    private void ResetDataGame()
    {
        VQMMAudio.Instance.LoadAudioBg();
        InteractableSpin(false);
        _txtQuestion.text = VQMMPRes.TitleStatGame;
        _txtDapAnA.text = "";
        _txtDapAnB.text = "";
        _txtDapAnC.text = "";
        _txtDapAnD.text = "";
        ResetPoint();
        // ShowGroupTgDapAn(true);
    }
    
    private void SetHieuUngDapAn(double index)
    {
        switch (index)
        {
            case 1:
                _huDapAnA.gameObject.SetActive(true);
                break;
            case 2:
                _huDapAnB.gameObject.SetActive(true);
                break;
            case 3:
                _huDapAnC.gameObject.SetActive(true);
                break;
            case 4:
                _huDapAnD.gameObject.SetActive(true);
                break;
        }
    }

    private void OffHieuUng()
    {
        _huDapAnA.gameObject.SetActive(false);
        _huDapAnB.gameObject.SetActive(false);
        _huDapAnC.gameObject.SetActive(false);
        _huDapAnD.gameObject.SetActive(false);
    }
    
    private void StartTime()
    {
        StartCoroutine(DemTime(31));
    }
    
    private void SetAnimSpin(int index)
    {
        InteractableSpin(false);
        int rotate = -3600;
        switch (index)
        {
            case PointX2 :
                rotate = -3570;
                break;
            case PointX3 :
                rotate = -3660;
                break;
            case PointX5 :
                rotate = -3780;
                break;
            case PointChiadoi :
                rotate = -3750;
                break;
            case PointMatdiem :
                rotate = -3600;
                break;
            case Point10 :
                rotate = -3810;
                break;
            case Point50 :
                rotate = -3690;
                break;
            case Point100 :
                rotate = -3900;
                break;
            case Point200 :
                rotate = -3720;
                break;
            case Point500 :
                rotate = -3870;
                break;
            case Point10000 :
                rotate = -3840;
                break;
            case Point100000 :
                rotate = -3990;
                break;
        }

        _imgVongQuay.transform.DOLocalRotate(new Vector3(0, 0, rotate), 3f).OnComplete(delegate
        {
            SetDiemHienTai(index);
            SetInfo();
        });
    }

    private int GetPoint()
    {
        int sum = phanTramX2 + phanTramX3 + phanTramX5 + phanTramChiaDoi + phanTramMatDiem + phanTram10 + phanTram50 +
                  phanTram100 + phanTram200 + phanTram500 + phanTram10000 + phanTram100000;
        int random = Random.Range(0, sum);

        if (random < phanTramX2) return PointX2;
        else if (random < phanTramX2 + phanTramX3) return PointX3;
        else if (random < phanTramX2 + phanTramX3 + phanTramX5) return PointX5;
        else if (random < phanTramX2 + phanTramX3 + phanTramX5 + phanTramChiaDoi) return PointChiadoi;
        else if (random < phanTramX2 + phanTramX3 + phanTramX5 + phanTramChiaDoi + phanTramMatDiem) return PointMatdiem;
        else if (random < phanTramX2 + phanTramX3 + phanTramX5 + phanTramChiaDoi + phanTramMatDiem + phanTram10) return Point10;
        else if (random < phanTramX2 + phanTramX3 + phanTramX5 + phanTramChiaDoi + phanTramMatDiem + phanTram10 + phanTram50) return Point50;
        else if (random < phanTramX2 + phanTramX3 + phanTramX5 + phanTramChiaDoi + phanTramMatDiem + phanTram10 + phanTram50 + phanTram100) return Point100;
        else if (random < phanTramX2 + phanTramX3 + phanTramX5 + phanTramChiaDoi + phanTramMatDiem + phanTram10 + phanTram50 + phanTram100 + phanTram200) return Point200;
        else if (random < phanTramX2 + phanTramX3 + phanTramX5 + phanTramChiaDoi + phanTramMatDiem + phanTram10 +
            phanTram50 + phanTram100 + phanTram200 + phanTram500) return Point500;
        else if (random < phanTramX2 + phanTramX3 + phanTramX5 + phanTramChiaDoi + phanTramMatDiem + phanTram10 +
            phanTram50 + phanTram100 + phanTram200 + phanTram500 + phanTram10000) return Point10000;
        else if (random < phanTramX2 + phanTramX3 + phanTramX5 + phanTramChiaDoi + phanTramMatDiem + phanTram10 +
            phanTram50 + phanTram100 + phanTram200 + phanTram500 + phanTram10000 +
            phanTram100000) return Point100000;

        return PointX2;
    }
    
    private void SetDiemHienTai(int index)
    {
        switch (index)
        {
            case 1:
                // ReSharper disable once ConvertToCompoundAssignment
                VQMMData.Instance.PointHienTai = VQMMData.Instance.PointHienTai * 2;
                break;
            case 2:
                // ReSharper disable once ConvertToCompoundAssignment
                VQMMData.Instance.PointHienTai = VQMMData.Instance.PointHienTai * 3;
                break;
            case 3:
                // ReSharper disable once ConvertToCompoundAssignment
                VQMMData.Instance.PointHienTai = VQMMData.Instance.PointHienTai * 5;
                break;
            case 4:
                // ReSharper disable once ConvertToCompoundAssignment
                VQMMData.Instance.PointHienTai = VQMMData.Instance.PointHienTai / 2;
                break;
            case 5:
                VQMMData.Instance.PointHienTai = 0;
                break;
            case 6:
                VQMMData.Instance.PointHienTai += 10;
                break;
            case 7:
                VQMMData.Instance.PointHienTai += 50;
                break;
            case 8:
                VQMMData.Instance.PointHienTai += 100;
                break;
            case 9:
                VQMMData.Instance.PointHienTai += 200;
                break;
            case 10:
                VQMMData.Instance.PointHienTai += 500;
                break;
            case 11:
                VQMMData.Instance.PointHienTai += 10000;
                break;
            case 12:
                VQMMData.Instance.PointHienTai += 100000;
                break;
        }

        UpdateDiemHienTai();
        SetDiemCaoNhat();
        
    }
    
    private void UpdateDiemHienTai()
    {
        _txtDiemHienTai.text = VQMMData.ShowPoint(VQMMData.Instance.PointHienTai);
    }
    
    private void SetDiemCaoNhat()
    {
        if (VQMMData.Instance.PointHienTai > PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint1))
        {
            PlayerPrefs.SetInt(VQMMKeySaverLocal.Maxpoint1,VQMMData.Instance.PointHienTai);
        }
        
        _txtDiemCaoNhat.text = VQMMData.ShowPoint(PlayerPrefs.GetInt(VQMMKeySaverLocal.Maxpoint1));
    }
    
    private void ResetChonDapAn()
    {
        DapAnChon = 0;
        _tgdapanA.isOn = false;
        _tgdapanB.isOn = false;
        _tgdapanC.isOn = false;
        _tgdapanD.isOn = false;
    }

    private void ResetPoint()
    {
        VQMMData.Instance.PointHienTai = 0;
        UpdateDiemHienTai();
        SetDiemCaoNhat();
    }
    
    
    private void ShowGroupTgDapAn(bool val = true)
    {
        _groupTgDapAn.gameObject.SetActive(val);
    }
    
    public void Show(bool val = true)
    {
        gameObject.SetActive(val);
    }
    
}
