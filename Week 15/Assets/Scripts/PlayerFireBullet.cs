using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireBullet : MonoBehaviour
{

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletspeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Z)) {
            GameObject gameManager = GameObject.Find("GameManager");
            BulletManager bulletManager = gameManager.GetComponent<BulletManager>();
            if(bulletManager.currentBullets >= 1) {
                bulletManager.RemoveBullet(1);
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletspeed;
            }
        }
    }
}
