using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointData : MonoBehaviour
{
    public string lastcpName; // last checkpoint crossed name
    public float lastcpTime; // last checkpoint crossed time

    void Start ()
    {
        lastcpName = "start";
        lastcpTime = Time.time;
    }

    public void updateCheckpointData(float time, string name)
    {
        lastcpName = name;
        lastcpTime = time;
    }

    public float getLastcpTime()
    {
        return lastcpTime;
    }
}
