using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    static int treasure = 0;

    public static void IncreaseTreasure(int amount){
        treasure += amount;
        Debug.Log("Player's treasure is : " + treasure);
    }
    public static int GetTreasure(){
        return treasure;
    }
}
