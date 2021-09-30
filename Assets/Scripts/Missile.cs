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

    private Quaternion _lookRotation;
    private Vector3 _direction;
    public Transform Target;
    public float RotationSpeed = 5f;

    protected override void Awake()
    {
        Speed = startSpeed;
        if (maxSpeed < startSpeed)
            maxSpeed = startSpeed;
        startTime = Time.time;
        base.Awake();
        Target = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        t += Time.deltaTime / timeToMax;
        float newSpeed = Mathf.Lerp(startSpeed, maxSpeed, t);
        SetVelocity(newSpeed);

        _direction = (Target.position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
    }
}
