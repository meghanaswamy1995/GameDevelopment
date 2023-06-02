using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShapeCubeClockwise : MonoBehaviour
{
    // Rotation Along Z Axis AntiClockwise
    public GameObject[] shapeCubes;
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
            gameObject.transform.localScale -= new Vector3(0f, 0.2f, 0f);
            for (int i = 0; i < shapeCubes.Length; i++)
            {
                StartCoroutine(RotateMe((new Vector3(0, 0, -1)) * 90, 0.7f, shapeCubes[i].transform));
            }
        }
    }

    // Release Button
    void OnTriggerExit(Collider other)
    {
        isBtnPressed = false;
        if (other.gameObject.tag == "Player")
        {
            gameObject.transform.localScale += new Vector3(0f, 0.2f, 0f);
            for (int i = 0; i < shapeCubes.Length; i++)
            {
                StartCoroutine(RotateMe((new Vector3(0, 0, 1)) * 90, 0.7f, shapeCubes[i].transform));
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
