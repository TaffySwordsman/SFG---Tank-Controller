using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float timeToMax;
    private float t = 0f;
    private float startTime;

    protected override void Awake() {
        Speed = startSpeed;
        if(maxSpeed < startSpeed)
            maxSpeed = startSpeed;
        startTime = Time.time;
        base.Awake();
    }

    private void FixedUpdate() {
        t += Time.deltaTime/timeToMax;
        float newSpeed = Mathf.Lerp(startSpeed, maxSpeed, t);
        SetVelocity(newSpeed);
    }
}
