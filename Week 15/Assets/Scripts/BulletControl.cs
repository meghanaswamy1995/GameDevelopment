using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public bool isPlayerHit;

    void Start()
    {
        isPlayerHit = false;
    }

    
    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Player" && isPlayerHit == false){
            isPlayerHit = true;
            GameObject gameManager = GameObject.Find("GameManager");
            print(col.contacts[0].point);
            gameManager.GetComponent<Health>().TakeDamage(1, col.contacts[0].point);
            print("Hit the player");
            Destroy(gameObject);
        }
    }
}
