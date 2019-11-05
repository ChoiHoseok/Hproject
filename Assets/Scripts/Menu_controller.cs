using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_controller : MonoBehaviour
{
    public GameObject controller;
    public Text Txt_name;
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        Txt_name.text = controller.GetComponent<Controller>().get_name();
    }

    private void Update()
    {
        
    }
}
