using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScreenText : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("LevelSelection");
        }
    }
}
