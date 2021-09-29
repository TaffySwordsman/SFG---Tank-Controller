using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] bool moving = false;
    [SerializeField] float speed = 5f;
    float randLocation = 0.0f;
    void Start()
    {
        InvokeRepeating("RandomizeMovement", 5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            CancelInvoke();
        
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
