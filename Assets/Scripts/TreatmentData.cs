using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class TreatmentData 
{
    public int comb_is_treat;
    public int[] comb_treats;
    public string comb_treat_explain;

    public ChimData[] ChimDatas;
    //public ChimData chimd = new ChimData();
    public int[] chuna_cate = new int[4];
    public string chuna_explain;

    public int[] hanyak_Prescriptions;
    public string hanyak_Prescription_other;
    public string hanyak_freq_time;
    public string hanyak_freq_day;
    public int hanyak_freq_timing;
    public string hanyak_freq_timing_other;
    //public int hanyak_freq_timing_other;
    public string hanyak_capa_explain;

    public int other_is_treat;
    public string other_explain;

    public string treat_plan;

    public int adverse_is_exist;
    public string adverse_explain;

    public void Initialize()
    {
        comb_is_treat = 0;
        comb_treats = new int[6];
        for (int i = 0; i < 6; i++)
        {
            //Debug.Log(i);
            comb_treats[i] = 0;
        }
        comb_treat_explain = "";
        ChimDatas = new ChimData[10];
        for (int i = 0; i < 10; i++)
        {
            //Debug.Log(i);
            ChimDatas[i] = new ChimData();
            ChimDatas[i].Initailize();
        }
        //chimd.Initailize();
        for(int i = 0; i < 4; i++)
        {
            chuna_cate[i] = 0;
        }
        chuna_explain = "";
        hanyak_Prescriptions = new int[4];
        for(int i = 0; i < 4; i++)
        {
            hanyak_Prescriptions[i] = 0;
        }
        hanyak_Prescription_other = "";
        hanyak_freq_time = "";
        hanyak_freq_day = "";
        hanyak_freq_timing = 0;
        hanyak_freq_timing_other = "";
        hanyak_capa_explain = "";
        other_is_treat = 0;
        other_explain = "";
        treat_plan = "";
        adverse_is_exist = 0;
        adverse_explain = "";
    }

}
