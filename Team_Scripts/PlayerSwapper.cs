using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



// public class PlayerSwapper : MonoBehaviour
// {
   
//     private GameObject player1;
//     private GameObject player2;
//     // Start is called before the first frame update
//     void Start()
//         {
//             player1 = GameObject.Find("Player 1");
//             player2 = GameObject.Find("Player 2");
//             Debug.Log("player1: " + player1);
//             Debug.Log("player2: " + player2);
            
//         }

//     // Update is called once per frame

//     void Update() 
//     {
//         if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) 
//         {
//             Debug.Log("Shift pressed");
//             Debug.Log("Player 1 position: " + player1.transform.position);
//             Debug.Log("Player 2 position: " + player2.transform.position);

//             Vector3 temp = player1.transform.position;
//             player1.transform.position = player2.transform.position;
//             player2.transform.position = temp;

//             Debug.Log("Player 1 position after swapping: " + player1.transform.position);
//             Debug.Log("Player 2 position after swapping: " + player2.transform.position);
//         }
//     }        
// }



public class PlayerSwapper : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    public float swapTime = 0.1f; // Time it takes to swap positions
    private bool isSwapping = false;

    void Start() {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
    }

    void Update() {
        if (!isSwapping && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))) {
            Debug.Log("Shift pressed");
            isSwapping = true;
            StartCoroutine(SwapPositions());
        }
    }

    IEnumerator SwapPositions() {
        Vector3 startPos1 = player1.transform.position;
        Vector3 startPos2 = player2.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < swapTime) {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / swapTime);
            player1.transform.position = Vector3.Lerp(startPos1, startPos2, t);
            player2.transform.position = Vector3.Lerp(startPos2, startPos1, t);
            yield return null;
        }

        isSwapping = false;
    }
}




// public class PlayerSwapper : MonoBehaviour
// {
//     public GameObject player1;
//     public GameObject player2;
//     public float moveTime = 0.5f;

//     // Start is called before the first frame update
//     void Start()
//     {
//         player1 = GameObject.Find("Player 1");
//         player2 = GameObject.Find("Player 2");
//         Debug.Log("player1: " + player1);
//         Debug.Log("player2: " + player2);
        
//     }

//     void Update() 
//     {
//         if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) 
//         {
//             Debug.Log("Shift pressed");
//             Debug.Log("Player 1 position: " + player1.transform.position);
//             Debug.Log("Player 2 position: " + player2.transform.position);

//             StartCoroutine(MovePlayers(player1, player2, moveTime));

//             Debug.Log("Player 1 position after swapping: " + player1.transform.position);
//             Debug.Log("Player 2 position after swapping: " + player2.transform.position);
//         }
//     }
//     private IEnumerator MovePlayers(GameObject player1, GameObject player2, float moveTime) {
//     Vector3 player1TargetPosition = player2.transform.position;
//     Vector3 player2TargetPosition = player1.transform.position;
//     Vector3 player1StartPosition = player1.transform.position;
//     Vector3 player2StartPosition = player2.transform.position;
//     float elapsedTime = 0.0f;
    
//     while (elapsedTime < moveTime) {
//         elapsedTime += Time.deltaTime;
//         float t = Mathf.Clamp01(elapsedTime / moveTime);
//         player1.transform.position = Vector3.Lerp(player1StartPosition, player1TargetPosition, t);
//         player2.transform.position = Vector3.Lerp(player2StartPosition, player2TargetPosition, t);
//         yield return null;
//     }
// }

// {
//     if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
//     Debug.Log("Shift pressed");
//     Debug.Log("Player 1 position: " + player1.transform.position);
//     Debug.Log("Player 2 position: " + player2.transform.position);

//     player1.transform.DOMove(player2.transform.position, 0.5f);
//     player2.transform.DOMove(player1.transform.position, 0.5f);

//     Debug.Log("Player 1 position after swapping: " + player1.transform.position);
//     Debug.Log("Player 2 position after swapping: " + player2.transform.position);
// }

// }


// }





