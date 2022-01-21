using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private GameObject _camDrone;

	public void DroneMove(Vector2 move)
	{
		Vector2 direction;

		direction = new Vector2(move.x, move.y);

		transform.Translate(new Vector3(direction.y, 0, -direction.x) * _speed * Time.deltaTime);
	}

	public void CameraDroneOn(bool cameraOF)
	{
		if (cameraOF)
		{
			_camDrone.SetActive(false);
		}
		else
			_camDrone.SetActive(true);
	}
}
