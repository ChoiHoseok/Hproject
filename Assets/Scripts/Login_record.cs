using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login_record : MonoBehaviour
{
    public Text rname;
    public Text rdate;
    public GameObject controller;

    private void Awake()
    {
        controller = GameObject.Find("controller");
    }

    public void SetNameDate(string name, string date)
    {
        rname.text = name;
        rdate.text = date;
    }

    public void Login_by_record()
    {
        controller.GetComponent<Controller>().Login(rname.text);
    }
}
