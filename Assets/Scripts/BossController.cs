using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossController : MonoBehaviour
{
    [SerializeField] bool moving = false;
    [SerializeField] float speed = 5f;
    public UnityEvent ReadyMissiles, UnreadyMissiles, HandSweep;
    float randLocation = 0.0f;
    void Start()
    {
        InvokeRepeating("RandomizeMovement", 5f, 3f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            CancelInvoke();

        if(Input.GetKeyDown(KeyCode.Q))
            HandSweep.Invoke();
        
        if(moving)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, randLocation, 0), Time.deltaTime * speed);
    }

    void RandomizeMovement()
    {
        var tempRandom = randLocation;

        if(moving)
            moving = false;
        else{moving = true;}

        randLocation = Random.Range(-90, 90);

    }
}
