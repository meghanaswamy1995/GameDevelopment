using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public Vector3 shootDirection = new Vector3(0, 90, 0); 
    public float bulletspeed = 10;
    public float bulletRate;
    public float initialDelay;

    
        //if (Time.time % 2 == 0) // Replace 2 with the desired shooting frequency
        //{
          //  Shoot();
        //}
    void Start()
    {
        //bulletSpawnPoint.transform.Rotate(shootDirection, Space.World);
        InvokeRepeating("Shoot", initialDelay, bulletRate);
    }
    
    void Shoot()
        { 
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletspeed;
         
        }
}
