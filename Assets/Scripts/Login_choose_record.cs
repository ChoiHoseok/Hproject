using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login_choose_record : MonoBehaviour
{
    public InputField InputF_name;
    public Text Txt_name;

    public void On_click()
    {
        InputF_name.text = Txt_name.text;    
    }
}
