using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletspeed = 10;

    void update()
    {
        if (Time.time % 2 == 0) // Replace 2 with the desired shooting frequency
        {
            Shoot();
        }
    }
    void Shoot()
        { 
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletspeed;
        }
    
}
