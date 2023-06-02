using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayers : MonoBehaviour
{
    // Start is called before the first frame update

    public bool onlyShape;
    public bool onlyColor;
    public List<Transform> possibleCharacters;

    void Start()
    {
        possibleCharacters = GameObject.Find("GameManager").GetComponent<CharacterSwap>().possibleCharacters;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {

            int count = 0;

            Transform player_1 = null;
            Transform player_2 = null;


            if(onlyColor) {
                for (int i=0; i<possibleCharacters.Count; i++) {
                    if(possibleCharacters[i].Find("Type").tag == "ColorPlayer") {
                        if(count > 1) {
                            player_2 = possibleCharacters[i];
                        } else {
                            player_1 = possibleCharacters[i];
                        }
                        count += 1;
                    }        
                }
            } else {
                for (int i=0; i<possibleCharacters.Count; i++) {
                    if(possibleCharacters[i].Find("Type").tag == "ShapePlayer") {
                        if(count > 1) {
                            player_2 = possibleCharacters[i];
                        } else {
                            player_1 = possibleCharacters[i];
                        }
                        count += 1;
                    }  
                }
            }

            if(player_1 != null && player_2 != null) {
                Vector3 player_1_pos = player_1.position;
                Vector3 player_2_pos = player_2.position;

                player_1.transform.position = new Vector3(player_2_pos.x, player_1_pos.y, player_2_pos.z);
                player_2.transform.position = new Vector3(player_1_pos.x, player_2_pos.y, player_1_pos.z);
            }
        }
    }
}
