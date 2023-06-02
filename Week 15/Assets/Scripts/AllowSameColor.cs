using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowSameColor : MonoBehaviour
{

    public Material myMaterial;
    public string top;
    public string bottom;
    public string left;
    public string right;
    public string front;
    public string back;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        bottom = top;
        right = left;
        back = front;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            string playerMaterial = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.name;
            string gameObjMaterial = myMaterial.name;

            if (playerMaterial.Contains(front))
            {
                print("Player can enter");
            }
            else
            {
                print("Player Cannot Enter");
                /*
                Vector3 damageCoordinates = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
                print(damageCoordinates);
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                for(int i = 0; i < players.Length; i++)
                {
                    players[i].gameObject.GetComponent<Health>().TakeDamage(1, damageCoordinates);
                }
                */

            }
        }
    }
}
