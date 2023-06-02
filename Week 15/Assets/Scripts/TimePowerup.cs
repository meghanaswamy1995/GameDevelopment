using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePowerup : MonoBehaviour
{

    [SerializeField]
    private float rotateSpeed = 180.0f;
    public float maxScale = 1.75f;
    public float minScale = 0.5f;
    public float scaleSpeed = 1f;

    public int extraTime = 20;


    public int healthIncrease = 1; // Amount of health to increase

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        float scale = Mathf.PingPong(Time.time * scaleSpeed, maxScale - minScale) + minScale;
        transform.localScale = new Vector3(scale, scale, scale);    
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
