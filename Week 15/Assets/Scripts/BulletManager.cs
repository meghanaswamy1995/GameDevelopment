using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{

    public int maxBullets = 6;
    public int currentBullets;
    public int prevBullets;

    public Image[] bullets;
    public Sprite bulletImg;

    // Start is called before the first frame update
    void Start()
    {
        //currentBullets = maxBullets;
        prevBullets = currentBullets;

        for (int i = 0; i < bullets.Length; i++) {

            if (i < currentBullets)
            {
                bullets[i].enabled = true;
            } 
            else
            {
                bullets[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(prevBullets != currentBullets) {
            for (int i = 0; i < bullets.Length; i++) {

                if (i < currentBullets)
                {
                    bullets[i].enabled = true;
                } 
                else
                {
                    bullets[i].enabled = false;
                }
            }
        }
    }

    public void AddBullet(int count) {
        if(currentBullets + count <= maxBullets) {
            currentBullets = currentBullets + count;
        }
    }

    public void RemoveBullet(int count) {
        if(currentBullets - count >= 0) {
            currentBullets = currentBullets - count;
        }
    }




}
