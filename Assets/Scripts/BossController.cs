using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossController : MonoBehaviour
{
    [SerializeField] bool moving = false;
    [SerializeField] float speed = 5f;
    public int phase = 0;
    public UnityEvent ReadyMissiles, UnreadyMissiles, FireMissiles, HandSweep, HandSlam, Alternate1, Alternate2, HideHead, ShowHead;
    float randLocation = 0.0f;
    void Start()
    {
        InvokeRepeating("RandomizeMovement", 3f, 3f);
        InvokeRepeating("RandomizeAttacks", 2f, 9f);
    }

    void Update()
    {

        // if (Input.GetKeyDown(KeyCode.E))
        //     CancelInvoke();

        // if (Input.GetKeyDown(KeyCode.Q))
        //     HandSweep.Invoke();

        // if (Input.GetKeyDown(KeyCode.R))
        //     HandSlam.Invoke();

        // if (Input.GetKeyDown(KeyCode.T))
        //     Alternate1.Invoke();

        // if (Input.GetKeyDown(KeyCode.Y))
        //     Alternate2.Invoke();

        // if (Input.GetKeyDown(KeyCode.V))
        //     FireMissiles.Invoke();

        if (moving)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, randLocation, 0), Time.deltaTime * speed);
    }

    void RandomizeMovement()
    {
        if (moving)
            moving = false;
        else { moving = true; }

        randLocation = Random.Range(-90, 90);
    }

    void RandomizeAttacks()
    {
        int randAttack = Random.Range(0, 4);
        switch (phase)
        {
            case 0:
                StartCoroutine(MissileLaunch());
                break;
            case 1:
                switch (randAttack % 2)
                {
                    case 0:
                        HandSweep.Invoke();
                        break;
                    case 1:
                        HandSlam.Invoke();
                        break;
                }
                break;
            case 2:
                switch (randAttack)
                {
                    case 0:
                        HandSweep.Invoke();
                        break;
                    case 1:
                        HandSlam.Invoke();
                        break;
                    case 2:
                        Alternate1.Invoke();
                        break;
                    case 3:
                        Alternate2.Invoke();
                        break;
                }
                break;
        }

    }

    IEnumerator MissileLaunch()
    {
        FireMissiles.Invoke();
        yield return new WaitForSeconds(3f);
        FireMissiles.Invoke();
        yield return new WaitForSeconds(3f);
        FireMissiles.Invoke();
    }
}
