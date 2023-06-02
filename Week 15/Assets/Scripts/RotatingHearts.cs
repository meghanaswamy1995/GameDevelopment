using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingHearts : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 150.0f;
    public float maxScale = 1.25f;
    public float minScale = 0.75f;
    public float scaleSpeed = 1f;

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
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.currentHealth += healthIncrease;
                playerHealth.maxHealth += healthIncrease;
            }
            Destroy(gameObject); 
        }
    }
}
