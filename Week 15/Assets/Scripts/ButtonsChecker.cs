using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsChecker : MonoBehaviour
{

    public List<GameObject> buttons;

    public bool isAnyPressed = false;

    public bool anyPressed() {
        for(int i=0; i < buttons.Count ; i++) {
            if(buttons[i].GetComponent<IsBtnPressed>().isPressed == true) {
                isAnyPressed = true;
                return true;
            }
        }
        isAnyPressed = false;
        return false;
    }

    void Update() {
        anyPressed();
    }
}
