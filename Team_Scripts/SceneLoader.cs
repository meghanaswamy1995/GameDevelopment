using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    void LoadNextScene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(Finish.sceneIndex + 1);
        }
    }
	
	public void Restart()
    {
        SceneManager.LoadScene(Finish.sceneIndex);
    }

    public void LoadLevelSelection()
    {
        SceneManager.LoadScene(1);
    }
}