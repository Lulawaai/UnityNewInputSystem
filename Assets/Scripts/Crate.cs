using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
	[SerializeField] private GameObject _destroyedCrate;

	[Header("Forces Modifiers")]
	[SerializeField] private float _power;
	[SerializeField] private float _radius;
	[SerializeField] private float _upwardsModifier;

	private void Start()
	{
	
	}
	public void DestroyCrate(float power)
	{
		_power = power;

		Debug.Log("DestroyCrate");

		GameObject cratePieces = Instantiate(_destroyedCrate, transform.position, Quaternion.identity);
		Rigidbody[] rbCratePieces = cratePieces.GetComponentsInChildren<Rigidbody>();

		if (rbCratePieces.Length > 0)
		{
			foreach(var body in rbCratePieces)
			{
				body.AddExplosionForce(_power, transform.position, _radius);
			}
		}
		Destroy(this.gameObject);
		
	}
}
