using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using UnityEngine.Networking;

public class SendToGoogle : MonoBehaviour   
{
   [SerializeField] 
   public string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeFdXylIKiPWuHQ2m9hdbRaK1hHstuWulbwfwRq8cb14sOR7w/formResponse"; 
  
    private long _sessionID;
    private string playerName;

    private string coordinateX; 
    private string coordinateZ;
    private int livesUsed; 
    private string livesEmptyFailure;
    private string timeOutFailure;
    private string winOrLoss = "win";
    private float timeTaken;

    private string levelName; 
    private string combinedActiveTime;
    private string playerSwapCount;
    private string combinedButtonPressCount; 

    private void Awake()
    {
    // Assign sessionID to identify playtests
        _sessionID = DateTime.Now.Ticks; 
        //Send();
    }
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(string _levelName, string _combinedActiveTime, string _playerSwapCount, string _combinedButtonPressCount) {
        levelName = _levelName;
        combinedActiveTime = _combinedActiveTime;
        playerSwapCount = _playerSwapCount;
        combinedButtonPressCount = _combinedButtonPressCount;
    }

    public void Send()
    {
        print("Sending Form Data");

        coordinateX = gameObject.GetComponent<Health>().coordinateX;
        coordinateZ = gameObject.GetComponent<Health>().coordinateZ; 
        livesEmptyFailure = gameObject.GetComponent<Health>().livesEmptyFailure;
        livesUsed = gameObject.GetComponent<Health>().currentHealth;
        timeOutFailure = gameObject.GetComponent<Timer>().timeOutFailure; 
        timeTaken = gameObject.GetComponent<Timer>().timeTaken;

        if(livesUsed <= 0){
            livesUsed = 3;
        }
        else{
            livesUsed = 3 - livesUsed;  
        }
        if(livesEmptyFailure == "true" || timeOutFailure == "true"){
            winOrLoss = "loss";
        }
        else{
            winOrLoss = "win";
        }

        StartCoroutine(Post(_sessionID.ToString(), livesUsed.ToString(), livesEmptyFailure, timeOutFailure, 
        coordinateX, coordinateZ, winOrLoss, timeTaken.ToString(), levelName, combinedActiveTime, playerSwapCount, combinedButtonPressCount));
    }


    private IEnumerator Post(string sessionID, string livesUsed, string livesEmptyFailure, string timeOutFailure, string coordinateX, 
    string coordinateZ, string winOrLoss, string timeTaken, string levelName, string combinedActiveTime, string playerSwapCount, string combinedButtonPressCount) 
    {
    // Create the form and enter responses
        WWWForm form = new WWWForm(); 

        form.AddField("entry.187399815", sessionID);
        form.AddField("entry.53462576", levelName); 
        form.AddField("entry.1525527248", livesUsed);
        form.AddField("entry.721119709", timeTaken);
        form.AddField("entry.504638561", winOrLoss); 
        form.AddField("entry.227985466", livesEmptyFailure); 
        form.AddField("entry.1919252074", timeOutFailure);
        form.AddField("entry.1373993647", combinedActiveTime);
        form.AddField("entry.1568785842", combinedButtonPressCount);
        form.AddField("entry.1430576982", playerSwapCount); 
        form.AddField("entry.1434263574", coordinateX); 
        form.AddField("entry.790890093", coordinateZ); 

    // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!"); 
            }
        }
    }
} 