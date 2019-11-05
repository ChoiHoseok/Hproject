using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class DiseaseData 
{
    public string main_harm;
    public int categori;
    public string when_where;
    public int[] beforeafters = new int[4];
    public string re_date;

    public void Initialize()
    {
        main_harm = "";
        categori = 0;
        when_where = "";
        
        for(int i =0; i< 4; i++)
        {
            beforeafters[i] = 0;
        }
        re_date = "";
    }
}
