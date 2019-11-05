using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Sportsharm_controller : MonoBehaviour
{
    public GameObject controller;
    public Scrollbar _scrollbar;
    public Text Txt_name;
    public int sph_num;
    

    public InputField InputF_main_harm;
    public Button Btn_copy;

    public GameObject cate_image;
    public int btn_num;
    public Text choosed_part;
    int choosed_part_id;
    Button[] Btn_cates;
    public string[] part_name;
    
    public GameObject Pan_kind;
    public GameObject Pan_reason;
    public GameObject Pan_jindan;

    Toggle[] togs_kind;
    Toggle[] togs_reason;
    Toggle[] togs_jindan;

    public int kind_tog_num;
    public int reason_tog_num;
    public int jindan_tog_num;

    public Dropdown kind_dropdown;
    public Dropdown reason_dropdown;

    public Toggle[] togs_when;
    public Toggle[] togs_when_new;
    public InputField InputF_when;
    public InputField InputF_howlong;
    public InputField InputF_other;

    public GameObject[] Pan_when;

    public InputField[] beforeafters;

    public Text Txt_date;

    private void Awake()
    {
        
        Btn_cates = new Button[btn_num];
        for (int i = 0; i < Btn_cates.Length; i++)
        {
            int _i = i;
            Btn_cates[i] = cate_image.transform.GetChild(i).GetComponent<Button>();
            Btn_cates[i].onClick.AddListener(delegate () { Set_part(_i + 1); }) ;
        }
        Btn_copy.onClick.AddListener(delegate () { Copy_main_harm(); });

        togs_kind = new Toggle[kind_tog_num];
        togs_reason = new Toggle[reason_tog_num];
        togs_jindan = new Toggle[jindan_tog_num];

        for (int i = 0; i < kind_tog_num; i++)
        {
            togs_kind[i] = Pan_kind.transform.GetChild(i).GetComponent<Toggle>();
        }

        for (int i = 0; i < reason_tog_num; i++)
        {
            togs_reason[i] = Pan_reason.transform.GetChild(i).GetComponent<Toggle>();
        }

        for (int i = 0; i < jindan_tog_num; i++)
        {
            togs_jindan[i] = Pan_jindan.transform.GetChild(i).GetComponent<Toggle>();
        }

    }

    private IEnumerator scrollsetting()
    {
        yield return null;
        _scrollbar.value = 1f;
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
        StartCoroutine(scrollsetting());
        Txt_name.text = controller.GetComponent<Controller>().get_name();

        //주요 증상 초기화
        InputF_main_harm.text = controller.GetComponent<Controller>().jdata.sh[sph_num].main_harm;
        //부위 초기화
        choosed_part.text = part_name[controller.GetComponent<Controller>().jdata.sh[sph_num].part];
        //종류란 초기
        if (controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[0] == 0)
        {
            for(int i = 0; i< kind_tog_num; i++)
            {
                togs_kind[i].isOn = false;
            }
            kind_dropdown.interactable = false;
            kind_dropdown.value = 0;
        }
        else if(controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[0] < kind_tog_num)
        {
            togs_kind[controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[0] - 1].isOn = true;
            kind_dropdown.interactable = false;
            kind_dropdown.value = 0;
        }
        else
        {
            togs_kind[kind_tog_num - 1].isOn = true;
            kind_dropdown.interactable = true;
            kind_dropdown.value = controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[0] - kind_tog_num + 1;
        }
        //원인 란 초기화
        if (controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[1] == 0)
        {
            for (int i = 0; i < reason_tog_num; i++)
            {
                togs_reason[i].isOn = false;
            }
            reason_dropdown.interactable = false;
            reason_dropdown.value = 0;
        }
        else if (controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[1] < reason_tog_num)
        {
            togs_reason[controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[1] - 1].isOn = true;
            reason_dropdown.interactable = false;
            reason_dropdown.value = 0;
        }
        else
        {
            togs_reason[reason_tog_num - 1].isOn = true;
            reason_dropdown.value = controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[1] - reason_tog_num + 1;
        }
        //진단 초기화
        for(int i = 0; i< jindan_tog_num; i++)
        {
            if(controller.GetComponent<Controller>().jdata.sh[sph_num].jindan[i] == 1)
            {
                togs_jindan[i].isOn = true;
            }
            else
            {
                togs_jindan[i].isOn = false;
            }
        }
        //언제 어떻게 초기화
        if(controller.GetComponent<Controller>().jdata.sh[sph_num].when == 0)
        {
            for(int i =0; i < togs_when.Length; i++)
            {
                togs_when[i].isOn = false;
            }
            
        }
        else
        {
            togs_when[controller.GetComponent<Controller>().jdata.sh[sph_num].when - 1].isOn = true;
        }
        if(controller.GetComponent<Controller>().jdata.sh[sph_num].new_harm == 0)
        {
            for (int i = 0; i < togs_when.Length; i++)
            {
                togs_when_new[i].isOn = false;
            }
        }
        else
        {
            togs_when_new[controller.GetComponent<Controller>().jdata.sh[sph_num].new_harm - 1].isOn = true;
        }
        InputF_when.text = controller.GetComponent<Controller>().jdata.sh[sph_num].new_when;
        InputF_howlong.text = controller.GetComponent<Controller>().jdata.sh[sph_num].how_long;
        InputF_other.text = controller.GetComponent<Controller>().jdata.sh[sph_num].other;
        //통증 이전 이후 초기화
        for (int i = 0; i < 6; i++)
        {
            beforeafters[i].text = controller.GetComponent<Controller>().jdata.sh[sph_num].beforeafters[i].ToString();
        }

        //날짜 초기화
        Txt_date.text = controller.GetComponent<Controller>().jdata.sh[sph_num].re_date;
    }

    // Update is called once per frame
    void Update()
    {
        //주요 증상
        controller.GetComponent<Controller>().jdata.sh[sph_num].main_harm = InputF_main_harm.text;
        //부위 종류 원인 진단
        controller.GetComponent<Controller>().jdata.sh[sph_num].part = choosed_part_id;
        Set_kind();
        Set_reason();
        for(int i = 0; i < jindan_tog_num; i++)
        {
            Set_jindan(i);
        }
        //언제 어떻게
        Set_when();

        for(int i = 0; i < 6; i++)
        {
            controller.GetComponent<Controller>().jdata.sh[sph_num].beforeafters[i] = int.Parse(beforeafters[i].text);
        }
        //날짜
        controller.GetComponent<Controller>().jdata.sh[sph_num].re_date = Txt_date.text;
    }

    public void Copy_main_harm()
    {
        //Debug.Log(controller.GetComponent<Controller>().jdata_prev.sh[sph_num].main_harm);
        InputF_main_harm.text = controller.GetComponent<Controller>().jdata_prev.sh[sph_num].main_harm;
    }

    public void Set_part(int id)
    {
        choosed_part.text = part_name[id];
        choosed_part_id = id;
    }
    public void Set_kind()
    {
        int ison = 0;
        for (int i = 0; i < kind_tog_num - 1; i++)
        {
            if (togs_kind[i].isOn)
            {
                controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[0] = i + 1;
                kind_dropdown.interactable = false;
                kind_dropdown.value = 0;
                ison = 1;
                break;
            }
        }
        if (togs_kind[kind_tog_num - 1].isOn)
        {
            kind_dropdown.interactable = true;
            if(kind_dropdown.value != 0)
                controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[0] = kind_dropdown.value + kind_tog_num - 1;
        }
        else if (ison == 0)
        {
            controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[0] = 0;
            kind_dropdown.interactable = false;
            kind_dropdown.value = 0;
        }

    }
    public void Set_reason()
    {
        int ison = 0;
        for(int i = 0; i < reason_tog_num - 1; i++)
        {
            if (togs_reason[i].isOn)
            {
                controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[1] = i + 1;
                reason_dropdown.interactable = false;
                reason_dropdown.value = 0;
                ison = 1;
                break;
            }
        }
        if(togs_reason[reason_tog_num - 1].isOn)
        {
            reason_dropdown.interactable = true;
            if(reason_dropdown.value != 0)
                controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[1] = reason_dropdown.value + reason_tog_num - 1;
        }
        else if(ison == 0)
        {
            controller.GetComponent<Controller>().jdata.sh[sph_num].categoris[1] = 0;
            reason_dropdown.interactable = false;
            reason_dropdown.value = 0;
        }
    }
    public void Set_jindan(int id)
    {
        if(togs_jindan[id].isOn)
        {
            controller.GetComponent<Controller>().jdata.sh[sph_num].jindan[id] = 1;
        }
        else
        {
            controller.GetComponent<Controller>().jdata.sh[sph_num].jindan[id] = 0;
        }
    }
    public void Set_when()
    {
        if (togs_when[0].isOn)
        {
            int is_new_on = 0;
            controller.GetComponent<Controller>().jdata.sh[sph_num].when = 1;
            Pan_when[0].SetActive(true);
            Pan_when[1].SetActive(false);
            Pan_when[2].SetActive(false);
            for(int i = 0; i < togs_when_new.Length; i++)
            {
                if (togs_when_new[i].isOn)
                {
                    is_new_on = 1;
                    controller.GetComponent<Controller>().jdata.sh[sph_num].new_harm = i + 1;
                    break;
                }
            }
            if(is_new_on == 0)
            {
                controller.GetComponent<Controller>().jdata.sh[sph_num].new_harm = 0;
            }
            controller.GetComponent<Controller>().jdata.sh[sph_num].new_when = InputF_when.text;
            controller.GetComponent<Controller>().jdata.sh[sph_num].how_long = "";
            controller.GetComponent<Controller>().jdata.sh[sph_num].other = "";
        }else if (togs_when[1].isOn)
        {
            controller.GetComponent<Controller>().jdata.sh[sph_num].when = 2;
            Pan_when[0].SetActive(false);
            Pan_when[1].SetActive(true);
            Pan_when[2].SetActive(false);
            controller.GetComponent<Controller>().jdata.sh[sph_num].new_when = "";
            controller.GetComponent<Controller>().jdata.sh[sph_num].new_harm = 0;
            controller.GetComponent<Controller>().jdata.sh[sph_num].how_long = InputF_howlong.text;
            controller.GetComponent<Controller>().jdata.sh[sph_num].other = "";

        }else if (togs_when[2].isOn)
        {
            controller.GetComponent<Controller>().jdata.sh[sph_num].when = 3;
            Pan_when[0].SetActive(false);
            Pan_when[1].SetActive(false);
            Pan_when[2].SetActive(true);
            controller.GetComponent<Controller>().jdata.sh[sph_num].new_when = "";
            controller.GetComponent<Controller>().jdata.sh[sph_num].new_harm = 0;
            controller.GetComponent<Controller>().jdata.sh[sph_num].how_long = "";
            controller.GetComponent<Controller>().jdata.sh[sph_num].other = InputF_other.text;
        }
        else
        {
            controller.GetComponent<Controller>().jdata.sh[sph_num].when = 0;
            Pan_when[0].SetActive(false);
            Pan_when[1].SetActive(false);
            Pan_when[2].SetActive(false);
            controller.GetComponent<Controller>().jdata.sh[sph_num].new_when = "";
            controller.GetComponent<Controller>().jdata.sh[sph_num].new_harm = 0;
            controller.GetComponent<Controller>().jdata.sh[sph_num].how_long = "";
            controller.GetComponent<Controller>().jdata.sh[sph_num].other = "";
        }
    }

    public void Getdate()
    {
        Txt_date.text = DateTime.Now.ToString("yyyy-MM-dd");
    }
    
}
