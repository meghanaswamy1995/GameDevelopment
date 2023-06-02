using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBunny : MonoBehaviour
{

    private static float normalSpeed = 0f;
    public float waterSpeed = 19f;
    public float woodSpeed = 11f;
    public float neutralizeTime = 10f;
    public IEnumerator coroutine;
    public bool CR_running = false;

    void Start()
    {
        CharacterControls characterControls = this.gameObject.GetComponent<CharacterControls>();
        normalSpeed = characterControls.speed;
        CR_running= false;
        coroutine = Neutralize();
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpTags powerUpTags = this.gameObject.GetComponent<PowerUpTags>(); 

        CharacterControls characterControls = this.gameObject.GetComponent<CharacterControls>();
        if (powerUpTags.HasTag("Water"))
        {
        } else if (powerUpTags.HasTag("Wood"))
        {
        } else
        {
        }
    }

    public void NeutralizeBunny()
    {
        print("Start Neutralize");
        StartCoroutine(coroutine);

    }

    public void StopNeutralizeBunny()
    {
        print("Stop Neutralize");
        StopCoroutine(coroutine);
    }

    IEnumerator Neutralize()
    {
        yield return new WaitForSeconds(neutralizeTime);
        print("Neutralize Bunny");

    }
}
