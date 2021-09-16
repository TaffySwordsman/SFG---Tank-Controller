using UnityEngine;

public class DamageableObject : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private int _curHealth;
    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound;
    [SerializeField] ParticleSystem _deathParticles;
    [SerializeField] AudioClip _deathSound;

    private void Start() {
        _curHealth = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        _curHealth -= amount;

        //particles
        if (_curHealth > 0)
            ImpactFeedback();

        if (_curHealth <= 0)
            Kill();
    }

    private void ImpactFeedback()
    {
        //particles
        if (_impactParticles != null)
        {
            Instantiate(_impactParticles, transform.position, Quaternion.identity);
        }

        if (_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);

        //particles
        if (_deathParticles != null)
        {
            Instantiate(_deathParticles, transform.position, Quaternion.identity);
        }

        if (_deathSound != null)
        {
            AudioHelper.PlayClip2D(_deathSound, 1f);
        }
    }

}
