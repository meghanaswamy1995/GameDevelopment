using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public int currentMana = 50;
    public int prevMana;
    public int maxMana = 100;
    public TextMeshProUGUI manaText;
    public Image manaFillImg;

    // Start is called before the first frame update

    void Start() {
        prevMana = currentMana;
        updateManaText(currentMana);
        updateManaFillValue(1.0f * maxMana, 1.0f * currentMana);
    }

    void printMana() {
        print("Current Mana: " + currentMana);
        print("Current Mana: " + maxMana);
    }

    void Update() {

        updateManaText(currentMana);
        updateManaFillValue(1.0f * maxMana, 1.0f * currentMana);

    }

    public void reduceMana(int reduceAmount) {
        if(currentMana - reduceAmount >= 0) {
            currentMana = currentMana - reduceAmount ;
        }
    }

    public void increaseMana(int addAmount) {

        if(currentMana < maxMana) {
            currentMana = currentMana + addAmount;
        }

        if(currentMana > maxMana) {
            currentMana = maxMana;
        }
    }

    public void updateManaFillValue(float maxMana, float currentMana) {
        manaFillImg.fillAmount = Mathf.InverseLerp(0, maxMana, currentMana);
    }

    public void updateManaText(int currentMana) {
        manaText.text = "" + currentMana + " %";
    }
}
