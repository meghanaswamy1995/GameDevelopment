using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RiverChange : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PowerUpTags powerUpTags = other.gameObject.GetComponent<PowerUpTags>();
            if(powerUpTags.HasTag("Wood")) 
            {
                // Get Collider of River
                Collider collider = gameObject.GetComponent<Collider>();
                MeshRenderer materialRenderer = gameObject.GetComponent<MeshRenderer>();

                // Disable Trigger
                collider.isTrigger = false;

                // Get Player Material
                GameObject playerGameObj = other.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject; 
                Material playerMaterial = playerGameObj.GetComponent<SkinnedMeshRenderer>().material;

                // Set river material to player material
                GetComponent<Renderer>().material = playerMaterial;

            } else if(powerUpTags.HasTag("Water")) {
                // Disable Trigger
                GetComponent<Collider>().isTrigger = false;

            } else
            {
                GetComponent<Collider>().isTrigger = true;  
            }


            // GameObject playerGameObj = other.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject; 
            //playerGameObj.GetComponent<SkinnedMeshRenderer>().material = powerUpMaterial;

            //Destroy(this.gameObject);

            //OnPickup();
        }
    }
}
