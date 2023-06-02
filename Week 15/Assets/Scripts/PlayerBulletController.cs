using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBulletController : MonoBehaviour
{
    public GameObject  healthTxt;

    void Start() {
        healthTxt.SetActive(false);
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Bullet"){
            healthTxt.SetActive(true);
            Invoke("disableHealthTxt", 1);
            
        }
    }

    void disableHealthTxt() {
        healthTxt.SetActive(false);
    }
    
}
