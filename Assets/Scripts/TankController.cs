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

    public float MaxSpeed{
        get => _maxSpeed;
        set => _maxSpeed = value;
    }

    Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(Input.GetButtonDown("Fire1")){
            Fire();
        }
            
    }

    private void FixedUpdate()
    {
        MoveTank();
        TurnTank();
    }

    private void Fire(){
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
        // calculate the move amount
        float moveAmountThisFrame = Input.GetAxis("Vertical") * _maxSpeed;
        // create a vector from amount and direction
        Vector3 moveOffset = transform.forward * moveAmountThisFrame;
        // apply vector to the rigidbody
        _rb.MovePosition(_rb.position + moveOffset);
        // technically adjusting vector is more accurate! (but more complex)
    }

    public void TurnTank()
    {
        // calculate the turn amount
        float turnAmountThisFrame = Input.GetAxis("Horizontal") * _turnSpeed;
        // create a Quaternion from amount and direction (x,y,z)
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        // apply quaternion to the rigidbody
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }
}
