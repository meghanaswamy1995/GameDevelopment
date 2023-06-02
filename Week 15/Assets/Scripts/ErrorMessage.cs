using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessage : MonoBehaviour
{

    public int messageTime = 5;

    public void ShowError() {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
     {        
         //Turn the Game Oject back off after 1 sec.
         yield return new WaitForSeconds(messageTime);
 
         //Game object will turn off
         gameObject.SetActive(false);
     }
}
