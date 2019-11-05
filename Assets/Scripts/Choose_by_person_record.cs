using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choose_by_person_record : MonoBehaviour
{
    public Text rdate;
    public GameObject controller;

    private void Awake()
    {
        controller = GameObject.Find("controller");
    }

    public void SetDate(string date)
    {
        rdate.text = date;
    }

    public void Choose_by_record()
    {
        controller.GetComponent<Controller>().SetJindan(rdate.text);
    }
}
