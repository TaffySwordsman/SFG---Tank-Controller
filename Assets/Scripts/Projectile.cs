using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Rigidbody rb;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private int _damage = 1;

    public float Speed{
        get { return _speed; }
        set {
            _speed = value;
            if(rb)
                rb.velocity = transform.forward * _speed;
        }
    }

    //visuals trail renderer

    protected virtual void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = transform.forward * _speed;
        Destroy(gameObject, lifeTime);
    }

    public void SetVelocity(float value) {
        Speed = value;
    }

    private void OnCollisionEnter(Collision other)
    {
        gameObject.SetActive(false);
        //when hitting an Entity, damage it and disable projectile
        IDamageable entity = other.gameObject.GetComponent<IDamageable>();
        if (entity != null)
        {
            entity?.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}
