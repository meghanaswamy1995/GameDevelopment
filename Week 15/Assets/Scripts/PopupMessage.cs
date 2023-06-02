using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMessage : MonoBehaviour
{
    public GameObject textObj;
    // Start is called before the first frame update
    void Start()
    {
        textObj.SetActive(true);
        StartCoroutine("WaitForSec");
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            textObj.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(7);
        textObj.SetActive(false);
    }
}
