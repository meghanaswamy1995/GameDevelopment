using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassChange : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            PowerUpTags powerUpTags = other.gameObject.GetComponent<PowerUpTags>();
            if (powerUpTags.HasTag("Fire"))
            {
                Destroy(this.gameObject);
            }
        }

    }

}
