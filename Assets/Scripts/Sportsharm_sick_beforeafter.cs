using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sportsharm_sick_beforeafter : MonoBehaviour
{
    public InputField InputF_sick;
    public Scrollbar Scb_sick;

    public void InputChange()
    {
        float value;
        value = float.Parse(InputF_sick.text);
        value /= 10;
        Scb_sick.value = value;
    }

    public void ScbChange()
    {
        float float_value;
        int int_value;
        float_value = Scb_sick.value * 10;
        int_value = (int)float_value;
        InputF_sick.text = int_value.ToString();
    }
}
