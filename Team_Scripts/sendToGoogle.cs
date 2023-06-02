using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using UnityEngine.Networking;

public class sendToGoogle : MonoBehaviour   
{
   [SerializeField] 
   public string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeFdXylIKiPWuHQ2m9hdbRaK1hHstuWulbwfwRq8cb14sOR7w/formResponse"; 
  
    private long _sessionID;
    private string playerName;
    private double timeConsumed; 

    private string coordinateX; 
    private string coordinateZ;
    private int livesUsed; 
    private string livesEmptyFailure;
    private string timeOutFailure;
    private string winOrLoss = "win";
    private float timeTaken;

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

    public void Send()
    {
        print("inside send ");

        timeConsumed = 5.0;
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

        StartCoroutine(Post(_sessionID.ToString(), timeConsumed.ToString(), livesUsed.ToString(), livesEmptyFailure, timeOutFailure, 
        coordinateX, coordinateZ, winOrLoss,timeTaken.ToString()));
    }


    private IEnumerator Post(string sessionID, string timeConsumed, string livesUsed, string livesEmptyFailure, string timeOutFailure, string coordinateX, 
    string coordinateZ, string winOrLoss, string timeTaken) 
    {
    // Create the form and enter responses
        WWWForm form = new WWWForm(); 
        //form.AddField("entry.187399815", sessionID);
        form.AddField("entry.1434263574", coordinateX); 
        form.AddField("entry.790890093", coordinateZ); 
        form.AddField("entry.1525527248", livesUsed);
        form.AddField("entry.504638561", winOrLoss); 
        form.AddField("entry.721119709", timeTaken);
        form.AddField("entry.227985466", livesEmptyFailure); 
        form.AddField("entry.1919252074", timeOutFailure);


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

//  currentHealth -= amount;

//         string x_pos = fallCoordinates.x.ToString();
//         string z_pos = fallCoordinates.z.ToString();

//         //analytics
//         coordinatesX[count] = x_pos;
//         coordinatesZ[count] = z_pos;
//         count++;
//         coX += " "+x_pos;
//         print(" Health ------- "); 
//         print(coX);
//         print("+++++++");


        
//         if (currentHealth <= 0)
//         {
//             gameObject.GetComponent<sendToGoogle>().Send(); 
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
//         }

//         attempt += 1;
