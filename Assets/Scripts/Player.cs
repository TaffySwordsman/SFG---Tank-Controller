using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;
    [SerializeField] ParticleSystem _deathParticles;
    [SerializeField] AudioClip _deathSound;
    [SerializeField] GameObject _body, _turret;
    [SerializeField] Material _matBase;
    [SerializeField] Material _matInvuln;
    bool _invincible = false;

    public bool Invincible{
        get { return _invincible; }
        set{
            if(value)
                ChangeColor(_matInvuln);
            else
                ChangeColor(_matBase);

            _invincible = value;
        }
    }

    TankController _tankController;

    private void Awake() {
       _tankController = GetComponent<TankController>(); 
    }

    private void Start() {
        _currentHealth = _maxHealth;
    }

    public void IncreaseHealth(int amount){
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void TakeDamage(int amount)
    {
        if(!_invincible){
            _currentHealth -= amount;
            Debug.Log("Player's health: " + _currentHealth);

            if(_currentHealth <= 0){
                Kill();
            }
        }
    }

    public void Kill(){
        if(!_invincible){
            gameObject.SetActive(false);
        
            //particles
            if(_deathParticles != null){
                _deathParticles = Instantiate(_deathParticles, transform.position, Quaternion.identity);
            }

            //audio. TODO - consider Object Pooling for performance
            if(_deathSound != null){
                AudioHelper.PlayClip2D(_deathSound, 1f);
            }
        }
    }

    public void ChangeColor(Material newColor){
        _body.GetComponent<MeshRenderer>().material = newColor;
        _turret.GetComponent<MeshRenderer>().material = newColor;
    }
}
