using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class JindanData
{
    public string pname_date;
    public SportsHarmData[] sh = new SportsHarmData[3];
    public DiseaseData Disease = new DiseaseData();
    public TreatmentData Treat = new TreatmentData();
    public ExerciseData Exercise = new ExerciseData();

    public void Initailize(string s)
    {
        pname_date = s;
        for(int i = 0; i < 3; i++)
        {
            sh[i] = new SportsHarmData();
            sh[i].Initialize();
        }
        Disease.Initialize();
        Treat.Initialize();
        Exercise.Initialize();
    }
}
