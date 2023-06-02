using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMana : MonoBehaviour
{
    public int addManaVal = 20;
    public float duration = 4.0f;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player) {
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<Mana>().increaseMana(addManaVal);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration); 

        Destroy(this);

        //GetComponent<MeshRenderer>().enabled = true;
        //GetComponent<Collider>().enabled = true;
    }
}
