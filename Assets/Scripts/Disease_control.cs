using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Disease_control : MonoBehaviour
{
    public GameObject controller;
    public Scrollbar _scrollbar;
    public Text Txt_name;

    public InputField InputF_main_harm;
    public InputField InputF_detail;
    public Dropdown Dropd_cate;

    public InputField[] InputF_beforeafter;
    public Text Txt_date;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        _scrollbar.value = 1;
        Txt_name.text = controller.GetComponent<Controller>().get_name();
        InputF_main_harm.text = controller.GetComponent<Controller>().jdata.Disease.main_harm;
        Dropd_cate.value = controller.GetComponent<Controller>().jdata.Disease.categori;
        InputF_detail.text = controller.GetComponent<Controller>().jdata.Disease.when_where;
        for (int i =0;i < 4; i++)
        {
            InputF_beforeafter[i].text = controller.GetComponent<Controller>().jdata.Disease.beforeafters[i].ToString();
        }
        Txt_date.text = controller.GetComponent<Controller>().jdata.Disease.re_date;
    }

    private void Update()
    {
        controller.GetComponent<Controller>().jdata.Disease.main_harm = InputF_main_harm.text;
        controller.GetComponent<Controller>().jdata.Disease.categori = Dropd_cate.value;
        controller.GetComponent<Controller>().jdata.Disease.when_where = InputF_detail.text;
        for(int i = 0; i< 4; i++)
        {
            controller.GetComponent<Controller>().jdata.Disease.beforeafters[i] = int.Parse(InputF_beforeafter[i].text);

        }
        controller.GetComponent<Controller>().jdata.Disease.re_date = Txt_date.text;

    }

    public void Getdate()
    {
        Txt_date.text = DateTime.Now.ToString("yyyy-MM-dd");
    }
    public void Copy_main()
    {
        InputF_main_harm.text = controller.GetComponent<Controller>().jdata_prev.Disease.main_harm;
    }
    public void Copy_when_where()
    {
        InputF_detail.text = controller.GetComponent<Controller>().jdata_prev.Disease.when_where;
    }
}
