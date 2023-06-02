using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float speed = 3f;
    public bool clockwise = true; 


    // Update is called once per frame
    void Update()
    {
        if (clockwise)
        {
            transform.Rotate(0f, 0f, speed * Time.deltaTime / 0.01f, Space.Self);
        }
        else
        {
            transform.Rotate(0f, 0f, speed * -1 * Time.deltaTime / 0.01f, Space.Self);
        }
    }
}
