using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : CollectibleBase
{

    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);

    [SerializeField] protected float powerupDuration = 2.5f;

    private MeshRenderer _renderer;
    private Collider _collider;

    private IEnumerator OnTriggerEnter(Collider other) {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Feedback();
            PowerUp(player);

            //disable visual components
            _renderer = gameObject.GetComponent<MeshRenderer>();
            _collider = gameObject.GetComponent<Collider>();
            if (_renderer != null && _collider != null)
            {
                _renderer.enabled = false;
                _collider.enabled = false;
            }

            //wait for duration
            yield return new WaitForSeconds(powerupDuration);

            PowerDown(player);
            gameObject.SetActive(false);
        }
    }
    protected override void Collect(Player player){}

}
