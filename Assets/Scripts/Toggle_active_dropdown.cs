using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle_active_dropdown : MonoBehaviour
{
    public Dropdown dd;

    Toggle t;

    private void Start()
    {
        t = GetComponent<Toggle>();
    }

    private void Update()
    {
        if (t.isOn)
        {
            dd.interactable = true;
        }
        else
        {
            dd.interactable = false;
        }
    }
}
