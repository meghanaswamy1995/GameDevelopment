using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TopDownCharacterMover : MonoBehaviour
{
    private InputHandler _input;

    public float moveSpeed;

    public float rotateSpeed;
 
    public Camera camera;

    public GameObject eyes;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        var movementVector = MoveTowardTarget(targetVector);

        if(eyes != null) {
            RotateTowardMovementVector(movementVector);
        }
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;
        transform.Translate(targetVector * speed);
        
        //var targetPosition =  transform.position + targetVector * speed;
        //transform.position = targetPosition;
        /*


        targetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        */
        return targetVector;
        //transform.Translate(targetVector * speed);
    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if(movementVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        eyes.transform.rotation = Quaternion.RotateTowards(eyes.transform.rotation, rotation, rotateSpeed);
    }


}
