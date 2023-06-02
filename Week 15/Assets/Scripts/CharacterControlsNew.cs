using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlsNew : MonoBehaviour
{
    public float speed = 10.0f;
    public float gravity = 10.0f;
    private Vector3 moveDir;
    private Rigidbody rb;
    public Vector3 checkPoint;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        checkPoint = transform.position;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {

    }


}
