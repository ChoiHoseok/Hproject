using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class SportsHarmData
{
	public string main_harm;
    public int part;
    public int[] categoris = new int[2];
    public int[] jindan = new int[7];
	public int when;
	public int new_harm;
    public string new_when;
	public string how_long;
	public string other;
    public string re_date;
    public int[] beforeafters = new int[6];

    public void Initialize()
    {
        main_harm = "";
        part = 0;
        for(int i =0; i<2; i++)
        {
            categoris[i] = 0;
        }
        for(int i = 0; i <7; i++)
        {
            jindan[i] = 0;
        }
        when = 0;
        new_harm = 0;
        new_when = "";
        how_long = "";
        other = "";
        re_date = "";
        for(int i = 0; i < 6; i++)
        {
            beforeafters[i] = 0;
        }
       
    }

}