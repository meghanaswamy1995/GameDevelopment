using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WinScreenText : MonoBehaviour
{

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
       float t = Timer.timeElapsed;

       string minutes = ((int)t / 60).ToString();
       string seconds = ((int)t % 60).ToString();

       if (seconds.Length < 2) seconds = "0" + seconds;
       if (minutes.Length < 2) minutes = "0" + minutes;


       timerText.text = minutes + " : " + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
