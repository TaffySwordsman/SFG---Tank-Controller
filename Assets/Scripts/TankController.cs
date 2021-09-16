using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] float _turnSpeed = 2f;
    [SerializeField] float _maxSpeed = .25f;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] ParticleSystem _fireFx;
    [SerializeField] AudioClip _fireSound;
    private Vector3 movement;

    public float MaxSpeed
    {
        get => _maxSpeed;
        set => _maxSpeed = value;
    }

    Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

    }

    private void FixedUpdate()
    {
        MoveTank();
    }

    private void Fire()
    {
        Instantiate(_bullet, _firePoint.position, _firePoint.rotation);

        if (_fireFx != null)
        {
            Instantiate(_fireFx, _firePoint.position, _firePoint.rotation);
        }

        if (_fireSound != null)
        {
            AudioHelper.PlayClip2D(_fireSound, 1f);
        }
    }

    public void MoveTank()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = 0;
        movement.z = Input.GetAxisRaw("Vertical");
        //Nerf double movement bug
        if(movement.magnitude > 1)
            movement = Vector3.Scale(movement, new Vector3(0.8f, 0, 0.8f));

        Vector3 moveDirection = movement * _maxSpeed;

        _rb.MovePosition(_rb.position + moveDirection);

        if (movement != Vector3.zero)
        {
            Quaternion moveRotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(moveDirection),
                                                    Time.deltaTime * _turnSpeed);
            _rb.MoveRotation(moveRotation);
        }
    }
}
