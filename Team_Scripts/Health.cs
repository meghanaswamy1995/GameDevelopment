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
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public string successStat = "fail";
    public long sessionID;
    public int attempt = 1;

    void Start()
    {
        currentHealth = maxHealth;
        sessionID = DateTime.Now.Ticks;
        attempt = 1;

    }

    public void TakeDamage(int amount, Vector3 fallCoordinates)
    {
        currentHealth -= amount;
        //successStat = "fail";
        
        //float timeTaken = this.gameObject.GetComponent<Timer>().timeTaken;

        string x_pos = fallCoordinates.x.ToString();
        string z_pos = fallCoordinates.z.ToString();

        //string obstacle1 = GameObject.Find("Obstacle1").GetComponent<SavPos>().obstacle1;
        //string obstacle2 = GameObject.Find("Obstacle2").GetComponent<SavPos>().obstacle2;
        //string obstacle3 = GameObject.Find("Obstacle3").GetComponent<SavPos>().obstacle3;
        //string obstacle4 = GameObject.Find("Obstacle4").GetComponent<SavPos>().obstacle4;

        //StartCoroutine(Post(sessionID.ToString(), attempt.ToString(), successStat, timeTaken.ToString(), x_pos, z_pos, obstacle1, obstacle2, obstacle3, obstacle4));

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        attempt += 1;
    }


    void Update()
    {
        for (int i = 0; i < hearts.Length; i++) {

            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
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
