using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerModule : MonoBehaviour
{
    public Text timer;
    public bool isUpdate = true;
    private float time = 0;

    public void OnStart()
    {
        timer.text = "Timer : 0";
        isUpdate = true;
        time = 0;
    }

    void Update()
    {
       if(isUpdate)
        {
            time += Time.deltaTime;
            string str = string.Format("{0:F2}", time);

            timer.text = "Timer:" + str;
        }
    }

}
