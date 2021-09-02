using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayTreasure : MonoBehaviour
{
    TextMeshProUGUI treasureDisplay;
    void Start()
    {
        treasureDisplay = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        treasureDisplay.text = Inventory.GetTreasure().ToString();
    }
}
