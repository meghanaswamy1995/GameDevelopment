using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup_Switch : MonoBehaviour
{

    public Image powerupFillImg;
    public float currentPowerupTime;
    public float maxPowerupTime = 10.0f;
    public bool isPressed = false;
    public int powerupCost = 20;

    public bool onlyShape;
    public bool onlyColor;
    public List<Transform> possibleCharacters;

    public GameObject switchError;
    public GameObject manaError;

    // Start is called before the first frame update
    void Start()
    {
        currentPowerupTime = 0.0f;
        powerupFillImg.fillAmount = currentPowerupTime;
        possibleCharacters = GameObject.Find("GameManager").GetComponent<CharacterSwap>().possibleCharacters;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && isPressed == false) {

            currentPowerupTime = maxPowerupTime;
            GameObject gameManager = GameObject.Find("GameManager");
            int currentMana = gameManager.GetComponent<Mana>().currentMana;
            bool isAnyPressed = gameManager.GetComponent<ButtonsChecker>().isAnyPressed;
            if(currentMana - powerupCost < 0 || isAnyPressed) {
                if(currentMana - powerupCost < 0) {
                    manaError.SetActive(true);
                    manaError.GetComponent<ErrorMessage>().ShowError();
                } else {
                    switchError.SetActive(true);
                    switchError.GetComponent<ErrorMessage>().ShowError();
                }
                return;
            }
            gameManager.GetComponent<Mana>().reduceMana(powerupCost);
            isPressed = true;

            int count = 0;

            Transform player_1 = null;
            Transform player_2 = null;


            if(onlyColor) {
                for (int i=0; i<possibleCharacters.Count; i++) {
                    if(possibleCharacters[i].Find("Type").tag == "ColorPlayer") {
                        count += 1;
                        if(count > 1) {
                            player_2 = possibleCharacters[i];
                        } else {
                            player_1 = possibleCharacters[i];
                        }

                    }        
                }
            } else {
                for (int i=0; i<possibleCharacters.Count; i++) {
                    print(possibleCharacters[i].Find("Type").tag);
                    if(possibleCharacters[i].Find("Type").tag == "ShapePlayer") {
                        count += 1;
                        if(count > 1) {
                            player_2 = possibleCharacters[i];
                        } else {
                            player_1 = possibleCharacters[i];
                        }

                    }  
                }
            }

            print(player_1);
            print(player_2);

            if(player_1 != null && player_2 != null) {
                Vector3 player_1_pos = player_1.position;
                Vector3 player_2_pos = player_2.position;

                player_1.transform.position = new Vector3(player_2_pos.x, player_1_pos.y, player_2_pos.z);
                player_2.transform.position = new Vector3(player_1_pos.x, player_2_pos.y, player_1_pos.z);
            }
        }
        
        if(isPressed == true) {
            if(currentPowerupTime <= 0) {
                currentPowerupTime = 0.0f;
                isPressed = false;
            } else {
                currentPowerupTime -= Time.deltaTime;
                updatePowerupFillValue(maxPowerupTime, currentPowerupTime);
            }
        }   
    }

    public void updatePowerupFillValue(float maxPowerupTime, float currentPowerupTime) {
        powerupFillImg.fillAmount = Mathf.InverseLerp(0, maxPowerupTime, currentPowerupTime);
    }
}
