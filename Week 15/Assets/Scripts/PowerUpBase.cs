using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{

    public virtual void OnPickup()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            MeshRenderer powerUpMeshRenderer = GetComponent<MeshRenderer>();
            Material powerUpMaterial = powerUpMeshRenderer.material;
            
            GameObject playerGameObj = other.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject; 
            playerGameObj.GetComponent<SkinnedMeshRenderer>().material = powerUpMaterial;

            PowerUpTags powerUpTags = other.gameObject.GetComponent<PowerUpTags>();
            List<string> powerUps = powerUpTags.All;
            string powerUpName = this.gameObject.tag;
            powerUpTags.EmptyPowerUps();
            powerUpTags.AddPowerUps(powerUpName);

            //Destroy(this.gameObject);

            SpecialBunny specialBunny = other.gameObject.GetComponent<SpecialBunny>();
            specialBunny.StopNeutralizeBunny();
            specialBunny.NeutralizeBunny();




            OnPickup();
        }

    }


}
