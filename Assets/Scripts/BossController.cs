using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossController : MonoBehaviour
{
    [SerializeField] bool moving = false;
    [SerializeField] float speed = 5f;
    public UnityEvent ReadyMissiles, UnreadyMissiles, FireMissiles, HandSweep, HandSlam, Alternate1, Alternate2, HideHead, ShowHead;
    float randLocation = 0.0f;
    void Start()
    {
        InvokeRepeating("RandomizeMovement", 3f, 3f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            CancelInvoke();

        if(Input.GetKeyDown(KeyCode.Q))
            HandSweep.Invoke();

        if(Input.GetKeyDown(KeyCode.R))
            HandSlam.Invoke();

        if(Input.GetKeyDown(KeyCode.T))
            Alternate1.Invoke();

        if(Input.GetKeyDown(KeyCode.Y))
            Alternate2.Invoke();

        if(Input.GetKeyDown(KeyCode.V))
            FireMissiles.Invoke();
        
        if(moving)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, randLocation, 0), Time.deltaTime * speed);
    }

    void RandomizeMovement()
    {
        if(moving)
            moving = false;
        else{moving = true;}

        randLocation = Random.Range(-90, 90);
    }
}
