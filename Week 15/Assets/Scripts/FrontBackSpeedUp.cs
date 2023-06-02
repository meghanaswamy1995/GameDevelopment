using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBackSpeedUp : MonoBehaviour
{

    private float originalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = GameObject.Find("Player 1").GetComponent<TopDownCharacterMover>().moveSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<TopDownCharacterMover>().moveSpeed += 15f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<TopDownCharacterMover>().moveSpeed = originalSpeed;  
        }
    }

}
