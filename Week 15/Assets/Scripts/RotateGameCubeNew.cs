using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class RotateGameCubeNew : MonoBehaviour
{
    // Rotate along Y Axis
    public GameObject[] gameCubes;
    public float y_RoationAngle;
    public float rotationSpeed;
    private bool isBtnPressed;

    void Start()
    {
        isBtnPressed = false;
    }

    // Press Button
    void OnTriggerEnter(Collider other)
    {
        isBtnPressed = true;
        if (other.gameObject.tag == "Player")
        {
             this.transform.parent.gameObject.GetComponent<IsBtnPressed>().isPressed = true;
            gameObject.transform.position -= new Vector3(0f, 0.4f, 0f);
            for(int i=0; i<gameCubes.Length; i++)
            {
                //StartCoroutine(RotateMe(Vector3.up * 90, 0.7f, gameCubes[i].transform.GetChild(3).transform));
                //RotateCube(Vector3.up * 90, 0.5f, gameCubes[i].transform.GetChild(3).transform);
                RotateCenter(gameCubes[i]);
                
            }
        }
    }

    // Release Button
    void OnTriggerExit(Collider other)
    {
        isBtnPressed = false;
        if (other.gameObject.tag == "Player")
        {
            this.transform.parent.gameObject.GetComponent<IsBtnPressed>().isPressed = false;
            gameObject.transform.position += new Vector3(0f, 0.4f, 0f);
            for (int i = 0; i < gameCubes.Length; i++)
            {
                //StartCoroutine(RotateMe(Vector3.up * 90, 0.7f, gameCubes[i].transform.GetChild(3).transform));
                //RotateCube(Vector3.up * 90, 0.5f, gameCubes[i].transform.GetChild(3).transform);
                RotateCenter(gameCubes[i]);
            }
        }
    }

    void RotateCenter(GameObject gameCube) 
    {
        if(isBtnPressed)
        {
            string frontColor = gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().front;
            string leftColor = gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().left;

            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().front = leftColor;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().left = frontColor;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().back = leftColor;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().right = frontColor;

            //Material topMaterial = gameCube.transform.GetChild(3).GetChild(2).GetComponent<Renderer>().material;
            //gameCube.transform.GetChild(0).GetComponent<Renderer>().material = topMaterial;

            Transform[] sides = gameCube.transform.GetChild(3).GetComponentsInChildren<Transform>();

            Color frontMaterialColor = sides[1].gameObject.GetComponent<Renderer>().material.color;
            Color leftMaterialColor = sides[5].gameObject.GetComponent<Renderer>().material.color;

            sides[1].gameObject.GetComponent<Renderer>().material.color = leftMaterialColor; 
            sides[2].gameObject.GetComponent<Renderer>().material.color = leftMaterialColor; 
            sides[5].gameObject.GetComponent<Renderer>().material.color = frontMaterialColor; 
            sides[6].gameObject.GetComponent<Renderer>().material.color = frontMaterialColor; 
        } else
        {
            string frontColor = gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().front;
            string leftColor = gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().left;

            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().front = leftColor;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().left = frontColor;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().back = leftColor;
            gameCube.transform.GetChild(0).GetComponent<AllowSameColor>().right = frontColor;
            //Material frontMaterial = gameCube.transform.GetChild(3).GetChild(1).GetComponent<Renderer>().material;
            //gameCube.transform.GetChild(0).GetComponent<Renderer>().material = frontMaterial;

            
            Transform[] sides = gameCube.transform.GetChild(3).GetComponentsInChildren<Transform>();

            Color frontMaterialColor = sides[1].gameObject.GetComponent<Renderer>().material.color;
            Color leftMaterialColor = sides[5].gameObject.GetComponent<Renderer>().material.color;

            sides[1].gameObject.GetComponent<Renderer>().material.color = leftMaterialColor; 
            sides[2].gameObject.GetComponent<Renderer>().material.color = leftMaterialColor; 
            sides[5].gameObject.GetComponent<Renderer>().material.color = frontMaterialColor; 
            sides[6].gameObject.GetComponent<Renderer>().material.color = frontMaterialColor; 

        }

    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime, Transform transform)
    {
        
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(byAngles) * fromAngle ;
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, rotationSpeed * t);
            yield return null;
        }  
    }

    void RotateCube(Vector3 byAngles, float inTime, Transform transform) {
        
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(byAngles) * fromAngle ;
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, rotationSpeed * t);
        }  
    }



}
