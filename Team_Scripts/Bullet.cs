using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Player;  // Reference to the Player GameObject
    // public float bulletSpeed = 10.0f;  // The speed of the bullet
    public float blinkDuration = 2.0f;  // The duration to blink the Player
    // public float messageDuration = 2.0f;  // The duration to show the message on the Player
    public Color blinkColor = new Color(1.0f, 0.0f, 0.0f, 0.5f);  // The color to blink the Player
    public float life = 3;
    void Awake()
    {
        Destroy(gameObject, life);

    }
    void onCollisionEnter(Collision collision)
    {
        Debug.Log("on collisiiiiionn enter");
        if (collision.gameObject.tag == "Player") {
            Debug.Log("hiiii i gottt hit inside ifff");
            // If the bullet hits the Player, make the Player blink and show the message
            Player.GetComponent<Renderer>().material.color = blinkColor;
            float blinkTimer = 0.0f;  // The timer to blink the Player
            // float messageTimer = 0.0f;  // The timer to show the message on the Player
            bool hasHitPlayer = true;  // Whether the bullet has hit the Player



            while (hasHitPlayer) {
                // Blink the Player and show the message for the specified durations
                blinkTimer += Time.deltaTime;
                if (blinkTimer >= blinkDuration) {
                    Player.GetComponent<Renderer>().material.color = Color.white;
                    // Player.GetComponentInChildren<Canvas>().enabled = false;
                    hasHitPlayer = false;
                    Destroy(gameObject);  // Destroy the bullet object
                } else {
                    float lerpValue = Mathf.PingPong(Time.time, 1.0f);
                    float r = Mathf.Lerp(blinkColor.r, 1.0f, lerpValue);
                    float g = Mathf.Lerp(blinkColor.g, 1.0f, lerpValue);
                    float b = Mathf.Lerp(blinkColor.b, 1.0f, lerpValue);
                    float a = Mathf.Lerp(blinkColor.a, 0.0f, lerpValue);
                    Player.GetComponent<Renderer>().material.color = new Color(r, g, b, a);
                    // if (messageTimer < messageDuration) {
                    //     Player.GetComponentInChildren<Canvas>().enabled = true;
                    //     messageTimer += Time.deltaTime;
                    // } else {
                    //     Player.GetComponentInChildren<Canvas>().enabled = false;
                    // }
                }
            }
        }

        print("Player touches bullet");
        Destroy(gameObject);
    }
}
