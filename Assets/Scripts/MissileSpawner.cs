using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject missile;

    public void FireMissiles(){
        if(gameObject.activeInHierarchy)
            Instantiate(missile, firePoint.position, firePoint.rotation);
    }
}
