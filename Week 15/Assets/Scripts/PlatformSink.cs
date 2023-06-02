using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlatformSink : MonoBehaviour
{
    private float sinkSpeed = 0.05f;
    private bool isFalling = false;


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            PowerUpTags powerUpTags = GameObject.FindWithTag("Player").GetComponent<PowerUpTags>();
            if (powerUpTags.HasTag("Wood") == false)
            {
                isFalling = true;
                Destroy(gameObject, 5);
            }
        }
    }

    void FixedUpdate()
    {
        if(isFalling)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - sinkSpeed, transform.position.z);    
        }
    }
}
