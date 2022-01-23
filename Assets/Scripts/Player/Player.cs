using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("Player Move")]
	[SerializeField] private float _speed;
	[SerializeField] private float _rotSpeed;

	private Vector3 direction;

	public void Move(Vector2 move)
	{
		direction.x = move.y;

		transform.Translate(direction * _speed * Time.deltaTime);

		Vector3 currentRot = transform.localEulerAngles;

		currentRot.y += move.x * _rotSpeed * Time.deltaTime;
		transform.localRotation = Quaternion.AngleAxis(currentRot.y, Vector3.up);
	}
}
