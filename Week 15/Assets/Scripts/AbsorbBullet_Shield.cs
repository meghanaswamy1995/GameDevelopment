using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbBullet_Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet"){
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<BulletManager>().AddBullet(1);
            Destroy(other.gameObject);
        }
    }
}
