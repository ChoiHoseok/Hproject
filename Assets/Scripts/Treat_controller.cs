using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treat_controller : MonoBehaviour
{
    public GameObject controller;
    public Scrollbar scrollbar;
    public Text Txt_name;

    public Toggle[] togs_iscomb;
    public Toggle[] togs_comb_treat;

    public InputField InputF_detail;

    public GameObject[] Pan_chims;

    Dropdown[] dropd_cate;
    InputField[] InputF_part;
    Dropdown[] dropd_chim_cate;

    GameObject[] Pan_chims_chims;
    GameObject[] Pan_yackchim;
    GameObject[] Pan_bongchim;

    Dropdown[] dropd_jachim_part;
    Dropdown[] dropd_yuchim_time;

    Dropdown[] yackchim_cate;
    Dropdown[] bongchim_skintest;

    InputField[] InputF_other;

    
    public Toggle[] togs_chuna_cate;
    public InputField InputF_chuna_detail;

    public Toggle[] togs_hanyack_pres;
    public InputField InputF_hanyack_pres_other;
    public InputField InputF_hanyack_freq_time;
    public InputField InputF_hanyack_freq_day;
    public Toggle[] togs_hanyak_timing;
    public InputField InputF_timing_other;

    public InputField InputF_hanyack_capa;

    public Dropdown dropd_other;
    public InputField InputF_other_detail;

    public InputField InputF_treat_plan;
    public Toggle[] togs_is_advers;
    public InputField InputF_advers_explain;

    private void Awake()
    {
        dropd_cate = new Dropdown[Pan_chims.Length];
        InputF_part = new InputField[Pan_chims.Length];
        dropd_chim_cate = new Dropdown[Pan_chims.Length];
        Pan_chims_chims = new GameObject[Pan_chims.Length];
        Pan_yackchim = new GameObject[Pan_chims.Length];
        Pan_bongchim = new GameObject[Pan_chims.Length];
        dropd_jachim_part = new Dropdown[Pan_chims.Length];
        dropd_yuchim_time = new Dropdown[Pan_chims.Length];
        yackchim_cate = new Dropdown[Pan_chims.Length];
        bongchim_skintest = new Dropdown[Pan_chims.Length];
        InputF_other = new InputField[Pan_chims.Length];

        //침 오브젝트 활성화
        for (int i = 0; i< Pan_chims.Length; i++)
        {
            dropd_cate[i] = Pan_chims[i].transform.GetChild(0).GetComponent<Dropdown>();
            InputF_part[i] = Pan_chims[i].transform.GetChild(1).GetComponent<InputField>();
            dropd_chim_cate[i] = Pan_chims[i].transform.GetChild(2).GetComponent<Dropdown>();
            Pan_chims_chims[i] = Pan_chims[i].transform.GetChild(3).gameObject;
            Pan_yackchim[i] = Pan_chims[i].transform.GetChild(4).gameObject;
            Pan_bongchim[i] = Pan_chims[i].transform.GetChild(5).gameObject;
            InputF_other[i] = Pan_chims[i].transform.GetChild(6).GetComponent<InputField>();
        }
        //침 오브젝트 안에 자식 오브젝트 활성화
        for(int i = 0; i < Pan_chims.Length; i++)
        {
            dropd_jachim_part[i] = Pan_chims_chims[i].transform.GetChild(0).GetComponent<Dropdown>();
            dropd_yuchim_time[i] = Pan_chims_chims[i].transform.GetChild(1).GetComponent<Dropdown>();
            yackchim_cate[i] = Pan_yackchim[i].transform.GetChild(0).GetComponent<Dropdown>();
            bongchim_skintest[i] = Pan_bongchim[i].transform.GetChild(0).GetComponent<Dropdown>();
        }
        
    }

    private void OnEnable()
    {
        Txt_name.text = controller.GetComponent<Controller>().get_name();
        scrollbar.value = 1;
        //병용치료 초기화
        switch (controller.GetComponent<Controller>().jdata.Treat.comb_is_treat)
        {
            case 0:
                for(int i = 0; i< 2; i++)
                {
                    togs_iscomb[i].isOn = false;
                }
                break;
            case 1:
                togs_iscomb[0].isOn = true;
                togs_iscomb[1].isOn = false;
                break;
            case 2:
                togs_iscomb[0].isOn = false;
                togs_iscomb[1].isOn = true;
                break;
            default:
                break;

        }
        for(int i = 0; i < togs_comb_treat.Length; i++)
        {
            if(controller.GetComponent<Controller>().jdata.Treat.comb_treats[i] == 1)
            {
                togs_comb_treat[i].isOn = true;
            }
            else
            {
                togs_comb_treat[i].isOn = false;
            }
        }
        InputF_detail.text = controller.GetComponent<Controller>().jdata.Treat.comb_treat_explain;

        //침 데이터 초기화
        for(int i = 0; i < Pan_chims.Length; i++)
        {
            dropd_cate[i].value = controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].categori;
            InputF_part[i].text = controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].part;
            dropd_chim_cate[i].value = controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].chim_categori;

            dropd_jachim_part[i].value = controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].chim_jachim_part;
            dropd_yuchim_time[i].value = controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].chim_yuchim_time;

            yackchim_cate[i].value = controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].yakchim_categori;
            bongchim_skintest[i].value = controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].bongchim_skintest;

            InputF_other[i].text = controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].other;
        }

        //추나 한약 기타 초기화
        for(int i = 0; i< togs_chuna_cate.Length; i++)
        {
            if(controller.GetComponent<Controller>().jdata.Treat.chuna_cate[i] == 1)
            {
                togs_chuna_cate[i].isOn = true;
            }
            else
            {
                togs_chuna_cate[i].isOn = false;
            }
        }
        InputF_chuna_detail.text = controller.GetComponent<Controller>().jdata.Treat.chuna_explain;
        for(int i = 0; i< togs_hanyack_pres.Length; i++)
        {
            if(controller.GetComponent<Controller>().jdata.Treat.hanyak_Prescriptions[i] == 1)
            {
                togs_hanyack_pres[i].isOn = true;
            }
            else
            {
                togs_hanyack_pres[i].isOn = false;
            }
        }
        InputF_hanyack_pres_other.text = controller.GetComponent<Controller>().jdata.Treat.hanyak_Prescription_other;
        InputF_hanyack_freq_time.text = controller.GetComponent<Controller>().jdata.Treat.hanyak_freq_time;
        InputF_hanyack_freq_day.text = controller.GetComponent<Controller>().jdata.Treat.hanyak_freq_day;
        if(controller.GetComponent<Controller>().jdata.Treat.hanyak_freq_timing == 0)
        {
            for(int i = 0; i < togs_hanyak_timing.Length; i++)
            {
                togs_hanyak_timing[i].isOn = false;
            }
        }
        else
        {
            togs_hanyak_timing[controller.GetComponent<Controller>().jdata.Treat.hanyak_freq_timing - 1].isOn = true;
        }
        InputF_hanyack_pres_other.text = controller.GetComponent<Controller>().jdata.Treat.hanyak_freq_timing_other;
        InputF_hanyack_capa.text = controller.GetComponent<Controller>().jdata.Treat.hanyak_capa_explain;
        dropd_other.value = controller.GetComponent<Controller>().jdata.Treat.other_is_treat;
        InputF_other_detail.text = controller.GetComponent<Controller>().jdata.Treat.other_explain;
        InputF_treat_plan.text = controller.GetComponent<Controller>().jdata.Treat.treat_plan;
        if(controller.GetComponent<Controller>().jdata.Treat.adverse_is_exist == 0)
        {
            for(int i =0; i< togs_is_advers.Length; i++)
            {
                togs_is_advers[i].isOn = false;
            }
        }
        else
        {
            togs_is_advers[controller.GetComponent<Controller>().jdata.Treat.adverse_is_exist - 1].isOn = true;
        }
        InputF_advers_explain.text = controller.GetComponent<Controller>().jdata.Treat.adverse_explain;
    }

    private void Update()
    {
        //병용치료 업데이트
        if(togs_iscomb[0].isOn)
        {
            controller.GetComponent<Controller>().jdata.Treat.comb_is_treat = 1;
            for(int i = 0; i < togs_comb_treat.Length; i++)
            {
                togs_comb_treat[i].interactable = true;
            }
        }
        else if (togs_iscomb[1].isOn)
        {
            controller.GetComponent<Controller>().jdata.Treat.comb_is_treat = 2;
            for(int i = 0; i< togs_comb_treat.Length; i++)
            {
                togs_comb_treat[i].isOn = false;
                togs_comb_treat[i].interactable = false;
            }
        }
        else
        {       
            controller.GetComponent<Controller>().jdata.Treat.comb_is_treat = 0;
            for (int i = 0; i < togs_comb_treat.Length; i++)
            {
                togs_comb_treat[i].interactable = false;
                togs_comb_treat[i].isOn = false;
            }
        }
        for(int i = 0; i< togs_comb_treat.Length; i++)
        {
            if(togs_comb_treat[i].isOn)
            {
                controller.GetComponent<Controller>().jdata.Treat.comb_treats[i] = 1;
            }
            else
            {
                controller.GetComponent<Controller>().jdata.Treat.comb_treats[i] = 0;
            }
        }
        controller.GetComponent<Controller>().jdata.Treat.comb_treat_explain = InputF_detail.text;

        //침 업데이트
        for(int i = 0; i< Pan_chims.Length; i++)
        {
            if(dropd_cate[i].value != 0)
            {
                InputF_part[i].interactable = true;
                dropd_chim_cate[i].interactable = true;
                InputF_other[i].interactable = true;
            }
            else
            {
                InputF_part[i].text = "";
                dropd_chim_cate[i].value = 0;
                InputF_other[i].text = "";
                InputF_part[i].interactable = false;
                dropd_chim_cate[i].interactable = false;
                InputF_other[i].interactable = false;
            }
            controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].categori = dropd_cate[i].value;
            controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].part = InputF_part[i].text;
            if(dropd_chim_cate[i].value == 1)
            {
                Pan_chims_chims[i].SetActive(true);
                Pan_yackchim[i].SetActive(false);
                Pan_bongchim[i].SetActive(false);
            }
            else if(dropd_chim_cate[i].value == 2)
            {
                Pan_chims_chims[i].SetActive(false);
                Pan_yackchim[i].SetActive(true);
                Pan_bongchim[i].SetActive(false);
            }
            else if (dropd_chim_cate[i].value == 3)
            {
                Pan_chims_chims[i].SetActive(false);
                Pan_yackchim[i].SetActive(false);
                Pan_bongchim[i].SetActive(true);
            }
            else
            {
                Pan_chims_chims[i].SetActive(false);
                Pan_yackchim[i].SetActive(false);
                Pan_bongchim[i].SetActive(false);
            }
            controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].chim_categori = dropd_chim_cate[i].value;
            controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].chim_jachim_part = dropd_jachim_part[i].value;
            controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].chim_yuchim_time = dropd_yuchim_time[i].value;
            controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].yakchim_categori = yackchim_cate[i].value;
            controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].bongchim_skintest = bongchim_skintest[i].value;
            controller.GetComponent<Controller>().jdata.Treat.ChimDatas[i].other = InputF_other[i].text;
        }
        //추나 한약 기타 업데이트
        for(int i = 0; i< togs_chuna_cate.Length; i++)
        {
            if (togs_chuna_cate[i].isOn)
            {
                controller.GetComponent<Controller>().jdata.Treat.chuna_cate[i] = 1;
            }
            else
            {
                controller.GetComponent<Controller>().jdata.Treat.chuna_cate[i] = 0;
            }
            
        }
        controller.GetComponent<Controller>().jdata.Treat.chuna_explain = InputF_chuna_detail.text;
        for(int i = 0; i< togs_hanyack_pres.Length; i++)
        {
            if (togs_hanyack_pres[i].isOn)
            {
                controller.GetComponent<Controller>().jdata.Treat.hanyak_Prescriptions[i] = 1;
            }
            else
            {
                controller.GetComponent<Controller>().jdata.Treat.hanyak_Prescriptions[i] = 0;
            }
        }
        controller.GetComponent<Controller>().jdata.Treat.hanyak_Prescription_other = InputF_hanyack_pres_other.text;
        controller.GetComponent<Controller>().jdata.Treat.hanyak_freq_time = InputF_hanyack_freq_time.text;
        controller.GetComponent<Controller>().jdata.Treat.hanyak_freq_day = InputF_hanyack_freq_day.text;
        int _is_timing_on = 0;
        for (int i = 0; i< togs_hanyak_timing.Length; i++)
        {
            if (togs_hanyak_timing[i].isOn)
            {
                _is_timing_on = 1;
                controller.GetComponent<Controller>().jdata.Treat.hanyak_freq_timing = i + 1;
                break;
            }
        }
        if(_is_timing_on == 0)
        {
            controller.GetComponent<Controller>().jdata.Treat.hanyak_freq_timing = 0;
        }
        controller.GetComponent<Controller>().jdata.Treat.hanyak_freq_timing_other = InputF_timing_other.text;
        controller.GetComponent<Controller>().jdata.Treat.hanyak_capa_explain = InputF_hanyack_capa.text;
        controller.GetComponent<Controller>().jdata.Treat.other_is_treat = dropd_other.value;
        controller.GetComponent<Controller>().jdata.Treat.other_explain = InputF_other_detail.text;
        //치료계획, 이상반응 업데이트
        controller.GetComponent<Controller>().jdata.Treat.treat_plan = InputF_treat_plan.text;
        int _is_advers_on = 0;
        for (int i =0; i< togs_is_advers.Length; i++)
        {
            if (togs_is_advers[i].isOn)
            {
                _is_advers_on = 1;
                controller.GetComponent<Controller>().jdata.Treat.adverse_is_exist = i + 1;
                break;
            }
        }
        if(_is_advers_on == 0)
        {
            controller.GetComponent<Controller>().jdata.Treat.adverse_is_exist = 0;
        }
        controller.GetComponent<Controller>().jdata.Treat.adverse_explain = InputF_advers_explain.text;

    }

    public void Copy_comb_detail()
    {
        InputF_detail.text = controller.GetComponent<Controller>().jdata_prev.Treat.comb_treat_explain;
    }
}
