using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressCount : MonoBehaviour
{
    public int buttonPressCount = 0;

    void Start()
    {
        buttonPressCount = 0;    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            buttonPressCount += 1;
        }
    }

}
