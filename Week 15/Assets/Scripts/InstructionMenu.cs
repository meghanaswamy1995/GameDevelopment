using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> instruction_items; 
    public GameObject instructionMenuUI;
    public int currentInstruction = 0;

    void Start()
    {
        StartCoroutine(Pause());
    }


    public void Resume() {
        instructionMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
    }

    IEnumerator Pause() {
        yield return new WaitForSeconds(0);
        instructionMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
    } 

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && currentInstruction < instruction_items.Count) {
            Next();
        }
    }

    public void Next() {
        instruction_items[currentInstruction].SetActive(false);
        currentInstruction += 1;

        if(currentInstruction >= instruction_items.Count) {
            Resume();
            return;
        }

        instruction_items[currentInstruction].SetActive(true);
        Time.timeScale = 0.0f;
    }     
}
