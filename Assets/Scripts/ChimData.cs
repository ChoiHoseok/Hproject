using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class ChimData
{
    public int categori;
    public string part;
    public int chim_categori;

    public int chim_jachim_part;
    public int chim_yuchim_time;
    public int yakchim_categori;
    public int bongchim_skintest;

    public string other;

    public void Initailize()
    {
        categori = 0;
        part = "";
        chim_categori = 0;
        chim_jachim_part = 0;
        chim_yuchim_time = 0;
        
        yakchim_categori = 0;
        bongchim_skintest = 0;
    }


}
