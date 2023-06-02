using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaChange : MonoBehaviour
{

    GameObject currentGameObject;
    public float alpha = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        currentGameObject = gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ChangeAlpha(currentGameObject.GetComponent<Renderer>().material, alpha);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ChangeAlpha(currentGameObject.GetComponent<Renderer>().material, 1.0f);
        }
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}
