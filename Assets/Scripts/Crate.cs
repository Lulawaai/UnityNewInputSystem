using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
	[SerializeField] private GameObject _destroyedCrate;
	[SerializeField] private GameObject _explosion;

	[Header("Forces Modifiers")]
	[SerializeField] private float _power;
	[SerializeField] private float _radius;
	[SerializeField] private float _upwardsModifier;

	private WaitForSeconds _waitFor05Secs = new WaitForSeconds(0.5f);

	public void DestroyCrate(float power)
	{
		_power = power;

		if (_power > 2)
		{
			Instantiate(_explosion);
			StartCoroutine(DelayExplosion());
		}
		else
			Explosion();
	}

	private IEnumerator DelayExplosion()
	{
		yield return _waitFor05Secs;
		Explosion();
	}

	private void Explosion()
	{
		GameObject cratePieces = Instantiate(_destroyedCrate, transform.position, Quaternion.identity);

		Rigidbody[] rbCratePieces = cratePieces.GetComponentsInChildren<Rigidbody>();

		if (rbCratePieces.Length > 0)
		{
			foreach (var body in rbCratePieces)
			{
				body.AddExplosionForce(_power, transform.position, _radius);
			}
		}
		Destroy(this.gameObject);
	}
}
