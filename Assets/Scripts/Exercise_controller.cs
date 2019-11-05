using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exercise_controller : MonoBehaviour
{
    public GameObject controller;
    public Text Txt_name;

    public InputField InputF_momentum;
    public InputField InputF_game_time;
    public InputField InputF_score;
    public InputField InputF_abil_per;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        Txt_name.text = controller.GetComponent<Controller>().get_name();
        InputF_momentum.text = controller.GetComponent<Controller>().jdata.Exercise.daily_exc_time;
        InputF_game_time.text = controller.GetComponent<Controller>().jdata.Exercise.game_time;
        InputF_score.text = controller.GetComponent<Controller>().jdata.Exercise.score;
        InputF_abil_per.text = controller.GetComponent<Controller>().jdata.Exercise.abil_per;
    }

    private void Update()
    {
        controller.GetComponent<Controller>().jdata.Exercise.daily_exc_time = InputF_momentum.text;
        controller.GetComponent<Controller>().jdata.Exercise.game_time = InputF_game_time.text;
        controller.GetComponent<Controller>().jdata.Exercise.score = InputF_score.text;
        controller.GetComponent<Controller>().jdata.Exercise.abil_per = InputF_abil_per.text;


    }
}
