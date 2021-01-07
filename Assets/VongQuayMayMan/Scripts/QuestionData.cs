using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionData
{
    public static QuestionData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new QuestionData();
            }
            return instance;
        }      
    }
    
    protected static QuestionData instance;
    
}
