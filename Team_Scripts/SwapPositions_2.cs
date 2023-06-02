using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerSwapper : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float moveTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        Debug.Log("player1: " + player1);
        Debug.Log("player2: " + player2);
        
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) 
        {
            Debug.Log("Shift pressed");
            Debug.Log("Player 1 position: " + player1.transform.position);
            Debug.Log("Player 2 position: " + player2.transform.position);

            StartCoroutine(MovePlayers(player1, player2, moveTime));

            Debug.Log("Player 1 position after swapping: " + player1.transform.position);
            Debug.Log("Player 2 position after swapping: " + player2.transform.position);
        }
    }
    private IEnumerator MovePlayers(GameObject player1, GameObject player2, float moveTime) {
    Vector3 player1TargetPosition = player2.transform.position;
    Vector3 player2TargetPosition = player1.transform.position;
    Vector3 player1StartPosition = player1.transform.position;
    Vector3 player2StartPosition = player2.transform.position;
    float elapsedTime = 0.0f;
    
    while (elapsedTime < moveTime) {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / moveTime);
        player1.transform.position = Vector3.Lerp(player1StartPosition, player1TargetPosition, t);
        player2.transform.position = Vector3.Lerp(player2StartPosition, player2TargetPosition, t);
        yield return null;
    }
}

{
    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
    Debug.Log("Shift pressed");
    Debug.Log("Player 1 position: " + player1.transform.position);
    Debug.Log("Player 2 position: " + player2.transform.position);

    player1.transform.DOMove(player2.transform.position, 0.5f);
    player2.transform.DOMove(player1.transform.position, 0.5f);

    Debug.Log("Player 1 position after swapping: " + player1.transform.position);
    Debug.Log("Player 2 position after swapping: " + player2.transform.position);
}

}


}

