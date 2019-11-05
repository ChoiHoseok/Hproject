using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class ExerciseData 
{
    public string daily_exc_time;
    public string game_time;
    public string score;
    public string abil_per;

    public void Initialize()
    {
        daily_exc_time = "";
        game_time = "";
        score = "";
        abil_per = "";
    }
}
