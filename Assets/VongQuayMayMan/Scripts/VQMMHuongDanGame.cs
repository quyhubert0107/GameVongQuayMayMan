using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VQMMHuongDanGame : MonoBehaviour
{
    private TextMeshProUGUI _txtHuongDanGame;
    // Start is called before the first frame update

    private void Awake()
    {
        _txtHuongDanGame = transform.Find("txtHuongDanGame").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        SetInfo();
    }
    
    private void SetInfo()
    {
        _txtHuongDanGame.text = LUAT_CHOI;
    }
    
    private string LUAT_CHOI =
        "- The game has a very simple gameplay. Your task is in 30 seconds, choose the correct answer of the question to win the bonus in that round.\n" +
        "- Each time you answer correctly click on the SPIN to get the corresponding bonus.\n"+
        "- In addition to playing games for entertainment, you also supplement your knowledge. Great!";
}
