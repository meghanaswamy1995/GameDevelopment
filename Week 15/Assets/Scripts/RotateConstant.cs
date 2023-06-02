using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateConstant : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 150.0f;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}