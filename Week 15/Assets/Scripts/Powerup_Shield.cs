using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup_Shield : MonoBehaviour
{
    // Start is called before the first frame update
    public Image powerupFillImg;
    public float currentPowerupTime;
    public float maxPowerupTime = 30.0f;
    public bool isPressed = false;
    public int powerupCost = 10;
    public Transform activeCharacter;
    public Color originalShieldColor;
    public GameObject activeShield;

    public GameObject manaError;

    void Start()
    {
        currentPowerupTime = 0.0f;
        powerupFillImg.fillAmount = currentPowerupTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isPressed == false)
            {
                currentPowerupTime = maxPowerupTime;
                GameObject gameManager = GameObject.Find("GameManager");
                int currentMana = gameManager.GetComponent<Mana>().currentMana;
                if(currentMana - powerupCost < 0) {
                    manaError.SetActive(true);
                    manaError.GetComponent<ErrorMessage>().ShowError();
                    return;
                }
                
                gameManager.GetComponent<Mana>().reduceMana(powerupCost);

                activeCharacter = gameManager.GetComponent<CharacterSwap>().activeCharacter;
                GameObject shield = activeCharacter.transform.Find("Shield").gameObject;
                activeShield = shield;
                shield.SetActive(true);
                originalShieldColor = shield.GetComponent<MeshRenderer>().material.color;
                isPressed = true;
            }
        
        if(isPressed == true) {
            if(currentPowerupTime <= 0) {
                currentPowerupTime = 0.0f;
                GameObject shield = activeCharacter.transform.Find("Shield").gameObject;
                shield.SetActive(false);
                shield.GetComponent<MeshRenderer>().material.color = originalShieldColor;
                isPressed = false;
            } else {
                currentPowerupTime -= Time.deltaTime;
                updatePowerupFillValue(maxPowerupTime, currentPowerupTime);
                Color color = originalShieldColor ;
                color.a = Mathf.InverseLerp(0, maxPowerupTime, currentPowerupTime)/2;
                activeShield.GetComponent<MeshRenderer>().material.color = color; 
            }
        }
    }

    public void updatePowerupFillValue(float maxPowerupTime, float currentPowerupTime) {
        powerupFillImg.fillAmount = Mathf.InverseLerp(0, maxPowerupTime, currentPowerupTime);
    }

}
