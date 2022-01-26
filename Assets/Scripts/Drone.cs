using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _thrust;

	[SerializeField] private GameObject _camDrone;
	[SerializeField] private Rigidbody _rBd;

	[SerializeField] private UIManager _uiManager;


	public void DroneMove(Vector2 move)
	{
		Vector2 direction;

		direction = new Vector2(move.x, move.y);

		transform.Translate(new Vector3(direction.y, 0, -direction.x) * _speed * Time.deltaTime);
	}

	public void CameraDroneOn()
	{
		_camDrone.SetActive(true);
		_uiManager.ThrustON();
	}

	public void CameraDroneOFF()
	{
		_camDrone.SetActive(false);
		_uiManager.ThrustOFF();
	}

	public void Thrust()
	{
		_rBd.AddForce(transform.up * _thrust);
	}
}
