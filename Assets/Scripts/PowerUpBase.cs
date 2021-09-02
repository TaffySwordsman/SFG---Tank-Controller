using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{
	[SerializeField] protected float powerupDuration = 2.5f;
	protected bool powered = false;

	IEnumerator PowerUp()
	{
		powered = true;

		yield return new WaitForSeconds(powerupDuration);

		powered = false;
	}

	public virtual void PowerDown()
	{
		powered = false;
		StopCoroutine("ActivateOverload");
		CancelInvoke();
	}
}
