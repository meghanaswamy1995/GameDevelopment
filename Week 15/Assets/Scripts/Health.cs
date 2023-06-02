using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Globalization;
using UnityEngine.Networking;
using System.Diagnostics;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeFdXylIKiPWuHQ2m9hdbRaK1hHstuWulbwfwRq8cb14sOR7w/formResponse";

    public int maxHealth = 3;
    public int currentHealth;
    public int prevHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public string successStat = "fail";
    public long sessionID;
    public int attempt = 1;

    public string coordinateX = ""; 
    public string coordinateZ = "";
    public string livesEmptyFailure = "false"; 

    void Start()
    {
        currentHealth = maxHealth;
        prevHealth = currentHealth;
        sessionID = DateTime.Now.Ticks;
        attempt = 1;

        for (int i = 0; i < hearts.Length; i++) {

            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
                hearts[i].color = Color.red;
            } else
            {
                hearts[i].color = Color.black;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            } 
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage(int amount, Vector3 fallCoordinates)
    {
        prevHealth = currentHealth;
        currentHealth -= amount;

        //successStat = "fail";
        
        //float timeTaken = this.gameObject.GetComponent<Timer>().timeTaken;

        string x_pos = fallCoordinates.x.ToString();
        string z_pos = fallCoordinates.z.ToString();

        coordinateX += x_pos+", ";  
        coordinateZ += z_pos+", "; 

        if (currentHealth < 0)
        {
            livesEmptyFailure = "true";
            gameObject.GetComponent<Analytics>().SendAnalytics();
            SceneManager.LoadScene("NoHealth Screen");
        }

        attempt += 1;

    }


    void Update()
    {
        if(prevHealth != currentHealth) {
            for (int i = 0; i < hearts.Length; i++) {

                if(i < currentHealth)
                {
                    hearts[i].sprite = fullHeart;
                    hearts[i].color = Color.red;
                } else
                {
                    hearts[i].color = Color.black;
                }

                if (i < maxHealth)
                {
                    hearts[i].enabled = true;
                } 
                else
                {
                    hearts[i].enabled = false;
                }
            }
        }

    }

    private IEnumerator Post(string sessionID, string attempt, string successStat, string timeTaken, string x_pos, string z_pos, string obstacle1, string obstacle2, string obstacle3, string obstacle4)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.187399815", sessionID);
        form.AddField("entry.1525527248", attempt);
        form.AddField("entry.721119709", timeTaken);
        form.AddField("entry.504638561", successStat);
        form.AddField("entry.1568785842", x_pos);
        form.AddField("entry.1440234542", z_pos);
        form.AddField("entry.227985466", obstacle1);
        form.AddField("entry.1919252074", obstacle2);
        form.AddField("entry.1373993647", obstacle3);
        form.AddField("entry.1409553061", obstacle4);

        // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                UnityEngine.Debug.Log(www.error);
            }
            else
            {
                UnityEngine.Debug.Log("Form upload complete!");
            }
        }
    }


}
