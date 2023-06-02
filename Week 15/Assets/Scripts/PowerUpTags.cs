using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTags : MonoBehaviour
{
    private List<string> _powerUps;
    private Material defaultMaterial = null;
    // Start is called before the first frame update
    void Start()
    {
        _powerUps = new List<string>();
        //defaultMaterial = gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material;
    }

    public List<string> All
    {
        get { return _powerUps; }
    }

    public void AddPowerUps(string name)
    {
        if(!_powerUps.Contains(name))
        {
            _powerUps.Add(name);
        }
    }

    public bool HasTag(string name)
    {
        return _powerUps.Contains(name);
    }

    public Material GetDefaultMaterial()
    {
        return defaultMaterial;
    }

    public void EmptyPowerUps()
    {
        _powerUps.Clear();
    }



}
