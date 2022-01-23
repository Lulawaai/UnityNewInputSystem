using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forklift : MonoBehaviour
{
	[Header("Forklift Move")]
	[SerializeField] private float _speed;
	[SerializeField] private float _rotSpeed;

	[SerializeField] private GameObject _forkliftCam;

	private Vector3 direction;

	public void MoveForklift(Vector2 move)
	{
		direction.z = move.y;

		transform.Translate(direction * _speed * Time.deltaTime);

		Vector3 currentRot = transform.localEulerAngles;

		currentRot.y += move.x * _rotSpeed * Time.deltaTime;
		transform.localRotation = Quaternion.AngleAxis(currentRot.y, Vector3.up);
	}

	public void ForkLiftCamON()
	{
		_forkliftCam.SetActive(true);
	}

	public void ForkLiftCamOFF()
	{
		_forkliftCam.SetActive(false);
	}
}
