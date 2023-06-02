using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaChangeGameCube : MonoBehaviour
{
    public float alpha = 0.5f;
    public GameObject gate;
    private Collider gateCollider;

    void Start()
    {
        gateCollider = gate.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            string playerMaterial = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.name;
            string frontColor = this.gameObject.transform.GetChild(0).GetComponent<AllowSameColor>().front;
            if (playerMaterial.Contains(frontColor))
            {
                ChangeAlpha(alpha);
                gateCollider.isTrigger = true;
            } else
            {

            }

        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ChangeAlpha(1.0f);
            gateCollider.isTrigger = false;
        }
    }

    void ChangeAlpha(float alphaVal)
    {
        
        Transform[] sides = this.gameObject.transform.GetChild(3).gameObject.GetComponentsInChildren<Transform>();
        for(int i = 0; i < sides.Length; i++)
        {
            Material mat = sides[i].gameObject.GetComponent<Renderer>().material;
            Color oldColor = mat.color;
            Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
            mat.SetColor("_Color", newColor);
        }

    }
}
