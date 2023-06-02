using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScale : MonoBehaviour
{
    public float scaleSpeed;
    public Vector3 targetScale;
    public bool isScale;
    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        isScale = false;
        originalScale =  transform.localScale;
    }


    void FixedUpdate()
    {
        if(isScale)
        {
            transform.localScale = Vector3.MoveTowards(
                transform.localScale,
                targetScale,
                Time.deltaTime * scaleSpeed
            ); 
        } else {
            transform.localScale = Vector3.MoveTowards(
                transform.localScale,
                originalScale,
                Time.deltaTime * scaleSpeed
            ); 
        }

    }
}
