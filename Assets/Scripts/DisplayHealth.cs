using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    Slider health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Slider>();
    }

    // Update is called once per frame
    public void SubtractHealth(){
        Debug.Log(health);
        health.value -= 1;
    }
}
