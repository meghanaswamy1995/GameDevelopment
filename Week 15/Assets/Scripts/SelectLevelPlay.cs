using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectLevelPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public string selectedLevelName;
    void Start()
    {
        selectedLevelName = "";
    }

    // Update is called once per frame
    void Update()
    {
        selectedLevelName = EventSystem.current.currentSelectedGameObject.name;
        if (Input.GetKeyDown(KeyCode.Space))
        {
                SceneManager.LoadScene(selectedLevelName);
        }
    }
}
