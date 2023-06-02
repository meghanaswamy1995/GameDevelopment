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
        if(timerText == null)
        {
            timerText = gameObject.GetComponent<UnityEngine.UI.Text>();
        }

        timerText.text = Timer.winScreenTimerText;
    }

}
