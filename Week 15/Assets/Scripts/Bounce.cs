using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float speed;
    public Vector3 pos1;  
    public Vector3 pos2;
    //new Vector3(16.19f,5.97f,-2.37f);
    //new Vector3(9.14f,5.97f,-2.37f);

    void Start() {
        pos1 = gameObject.transform.position;
        pos2 = new Vector3(pos1.x, pos1.y + 2.0f, pos1.z);
    }
 
    void Update() {
        pos1 = gameObject.transform.position;
        pos2 = new Vector3(pos1.x, pos1.y + 2.0f, pos1.z);
        transform.position = Vector3.Lerp (pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
     }
}
