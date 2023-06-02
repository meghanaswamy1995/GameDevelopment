using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShapeCubeAnti : MonoBehaviour
{
    // Rotation Along Z Axis AntiClockwise
    public GameObject[] shapeCubes;
    public float rotationSpeed;
    private bool isBtnPressed;
    public bool X;
    public bool Y;
    public bool Z;

    void Start()
    {
        isBtnPressed = false;
        X = false;
        Y = false;
        Z = true;
    }

    // Press Button
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.transform.parent.gameObject.GetComponent<IsBtnPressed>().isPressed = true;
            gameObject.transform.localScale -= new Vector3(0f, 0.2f, 0f);
            for (int i = 0; i < shapeCubes.Length; i++)
            {
                if(X == true) {
                    StartCoroutine(RotateMe((new Vector3(1, 0, 0)) * 90, 0.7f, shapeCubes[i].transform));
                } else if(Y == true) {
                    StartCoroutine(RotateMe((new Vector3(0, 1, 0)) * 90, 0.7f, shapeCubes[i].transform));
                } else {
                    StartCoroutine(RotateMe((new Vector3(0, 0, 1)) * 90, 0.7f, shapeCubes[i].transform));
                }
                
            }
            isBtnPressed = true;
        }
    }

    // Release Button
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isBtnPressed = false;
            this.transform.parent.gameObject.GetComponent<IsBtnPressed>().isPressed = false;
            gameObject.transform.localScale += new Vector3(0f, 0.2f, 0f);
            for (int i = 0; i < shapeCubes.Length; i++)
            {
                if(X == true) {
                    StartCoroutine(RotateMe((new Vector3(-1, 0, 0)) * 90, 0.7f, shapeCubes[i].transform));
                } else if(Y == true) {
                    StartCoroutine(RotateMe((new Vector3(0, -1, 0)) * 90, 0.7f, shapeCubes[i].transform));
                } else {
                    StartCoroutine(RotateMe((new Vector3(0, 0, -1)) * 90, 0.7f, shapeCubes[i].transform));
                }
               
            }
        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime, Transform transform)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(byAngles) * fromAngle;
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, rotationSpeed * t);
            yield return null;
        }
    }


}
