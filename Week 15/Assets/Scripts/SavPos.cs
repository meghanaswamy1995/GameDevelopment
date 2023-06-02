using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavPos : MonoBehaviour
{
    public string obstacle1 = "";
    public string obstacle2 = "";
    public string obstacle3 = "";
    public string obstacle4 = "";

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            CheckpointData checkpointData = col.gameObject.GetComponent<CheckpointData>();
            float lastcpTime = checkpointData.getLastcpTime();
            float currentcpTime = Time.time;
            string cpName = gameObject.name;
            checkpointData.updateCheckpointData(currentcpTime, cpName);
            Neutralize(col);
            sendCheckpointData(lastcpTime, currentcpTime, cpName);

        }
    }

    public void Neutralize(Collider col)
    {
        GameObject playerGameObj = col.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        PowerUpTags powerUpTags = col.gameObject.GetComponent<PowerUpTags>();
        powerUpTags.EmptyPowerUps();
        playerGameObj.GetComponent<SkinnedMeshRenderer>().material = powerUpTags.GetDefaultMaterial();
    }

    void sendCheckpointData(float lastcpTime, float currentcpTime, string cpName) 
    {
        float cpSpendTime = currentcpTime - lastcpTime;

        string minutes = ((int)cpSpendTime / 60).ToString();
        string seconds = ((int)cpSpendTime % 60).ToString();

        if (seconds.Length < 2) seconds = "0" + seconds;
        if (minutes.Length < 2) minutes = "0" + minutes;

        string timeText = minutes + " : " + seconds;

        if (cpName == "Obstacle1")
        {
            obstacle1 = timeText;
        }
        else if (cpName == "Obstacle2")
        {
            obstacle2 = timeText;
        }
        else if (cpName == "Obstacle3")
        {
            obstacle3 = timeText;
        }
        else
        {
            obstacle4 = timeText;
        }



    }


}
