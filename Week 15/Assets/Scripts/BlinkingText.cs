using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    public float blinkRate = 0.5f;
    private Text flickeringText;
    private Color textColor;

    void Start()
    {
        flickeringText = gameObject.GetComponent<Text>();
        textColor = flickeringText.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(flickeringText != null) {
            textColor.a = 0.0f + Mathf.PingPong(Time.time * blinkRate, 1.0f);
            flickeringText.color = textColor;
        }
    }
}
