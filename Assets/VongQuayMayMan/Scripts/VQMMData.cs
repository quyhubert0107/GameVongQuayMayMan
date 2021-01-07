using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VQMMData
{
    public static VQMMData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new VQMMData();
            }
            return instance;
        }      
    }
    
    protected static VQMMData instance;
    public int PointHienTai { get; set; }
    
    public List<Question> dataVQMMQuestion = new List<Question>();
    private int RandomQuestion { get; set; }
    
    public Question GetDataVqmmQuestionRandom() => GetDataVqmmQuestionRandom(dataVQMMQuestion);

    public Question GetDataVqmmQuestionRandom(List<Question> list)
    {
        GetRandom(list);
        for (int i = 0; i < list.Count; i++)
        {
            if (i == RandomQuestion)
                return list[i];
        }
        return list[0];
    }

    public void GetRandom(List<Question> list)
    {
        int lengt = list.Count;
        int random = Random.Range(0, lengt - 1);
        RandomQuestion = random;
    }

    #region ShowMoney
    public static string ShowPoint(int money)
    {
        return ConverPoint(money);
    }
    static string ConverPoint(int point)
    {
        string ss = "";
        if (point >= 0 && point < 1000)
        {
            return point.ToString();
        }
        else if (point >= 1000 && point < 1000000)
        {
            ss = point.ToString("0,0");
        }
        else if (point >= 1000000)
        {
            ss = point.ToString("0,0,0");
        }
        return ss != "00" ? ss : "0";
    }
    
    #endregion

    public void ClearData()
    {
        dataVQMMQuestion.Clear();
    }
}
