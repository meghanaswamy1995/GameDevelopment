using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCornerValues : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider collider = GetComponent<Collider>();  
        print(collider.bounds.min.x);
        print(collider.bounds.min.z);
        print(collider.bounds.max.x);
        print(collider.bounds.max.z);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
