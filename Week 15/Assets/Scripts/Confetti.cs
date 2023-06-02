using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    [SerializeField]
    private GameObject _confetti;
    
    void Start()
    {
        if(_confetti != null)
        {
            _confetti.SetActive(false);
        }
    }

    public void enableConfetti()
    {
        _confetti.SetActive(true);
    }
}
