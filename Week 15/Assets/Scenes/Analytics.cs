using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Analytics : MonoBehaviour
{

    public List<string> playerSwitchOrder;
    public List<float> playerActiveTimeOrder;

    public void PlayersActiveTime(string playerName, float activeTime) {
        playerActiveTimeOrder.Add(activeTime);
        playerSwitchOrder.Add(playerName);
    }

    public string GenerateActiveTimeData() {
        string combinedActiveTime = "";

        for(int i=0; i<playerSwitchOrder.Count; i++){
            combinedActiveTime += playerSwitchOrder[i].ToString() + ":" + playerActiveTimeOrder[i].ToString() + " ";
        }
        combinedActiveTime = combinedActiveTime.Trim();

        return combinedActiveTime;
    }

    public string GeneratePlayerSwapCount() {
        int playerSwapCount = this.gameObject.GetComponent<CharacterSwap>().swapCount - 1;
        if(playerSwapCount == 0){
            return "";
        }
        return playerSwapCount.ToString(); 
    }

    public string GenerateButtonPressCount() {
        string combinedButtonPressCount = "";

        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        for(int i=0; i<buttons.Length; i++) {
            string buttonName = buttons[i].name;
            buttonName = buttonName.Replace("Button ","B");
            
            int buttonPressCount = buttons[i].transform.Find("Btn").gameObject.GetComponent<ButtonPressCount>().buttonPressCount; 
            combinedButtonPressCount += buttonName + ":" + buttonPressCount + " ";
        }

        combinedButtonPressCount = combinedButtonPressCount.Trim();
        return combinedButtonPressCount;
    }

    public string GenerateLevelName() {
        return SceneManager.GetActiveScene().name;
    }

    public void SendAnalytics() {

        // 1. Make sure each Button has a Button tag
        // 2. Make sure name of each Button is Button <Number>
        // 3. Attach ButtonPressCount script to Btn child of every Button  

        string levelName = GenerateLevelName();
        print(levelName);

        string combinedActiveTime = GenerateActiveTimeData();
        print(combinedActiveTime);

        string playerSwapCount = GeneratePlayerSwapCount();
        print(playerSwapCount);

        string combinedButtonPressCount = GenerateButtonPressCount();
        print(combinedButtonPressCount);

        gameObject.GetComponent<SendToGoogle>().SetData(levelName, combinedActiveTime, playerSwapCount, combinedButtonPressCount);
        gameObject.GetComponent<SendToGoogle>().Send();
    }
}
