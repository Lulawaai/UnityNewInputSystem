using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
	private GameInputActions _input;

	[Header("ActionMaps")]
	[SerializeField] private Player _player;
	[SerializeField] private Drone _drone;
	[SerializeField] private Forklift _forkLift;
	[SerializeField] private Crate _crate;

	[SerializeField] private int _actionMapActive;

	[Header("Crate Power")]
	[SerializeField] private float _softPower;
	[SerializeField] private float _hardPower;
	private bool _crateExploded = false;

	void Start()
	{
		_input = new GameInputActions();
		_input.Enable();

		//Player
		_input.PlayerMoves.Enable();
		_input.PlayerMoves.DroneSwitch.performed += DroneSwitch_performed;

		//Drone
		_input.Drone.Disable();
		_input.Drone.ForkliftSwitch.performed += ForkliftSwitch_performed;
		_input.Drone.Thrust.performed += Thrust_performed;

		//Forklift
		_input.Forklift.Disable();
		_input.Forklift.PlayerSwitch.performed += PlayerSwitch_performed;

		//Crate
		_input.Crate.Enable();
		_input.Crate.Explode.performed += Explode_performed;
		_input.Crate.Explode.canceled += Explode_canceled;
	}

	private void Explode_canceled(InputAction.CallbackContext context)
	{
		var duration = context.duration;

		if (duration >= 1 && _crateExploded == false)
		{
			_crateExploded = true;
			_crate.DestroyCrate(_hardPower);
		}
	}

	private void Explode_performed(InputAction.CallbackContext context)
	{
		if (_crateExploded == false)
		{
			_crateExploded = true;
			_crate.DestroyCrate(_softPower);
		}
	}

	//order actionMap
	// 1 - Player
	// 2 - Drone
	// 3 - Forklift

	private void DroneSwitch_performed(InputAction.CallbackContext context)
	{
		_actionMapActive = 1;
		_drone.CameraDroneOn();
		_input.PlayerMoves.Disable();
		_input.Drone.Enable();
	}

	private void ForkliftSwitch_performed(InputAction.CallbackContext context)
	{
		_actionMapActive = 2;
		_input.Forklift.Enable();
		_forkLift.ForkLiftCamON();
		_drone.CameraDroneOFF();
		_input.Drone.Disable();
	}

	private void PlayerSwitch_performed(InputAction.CallbackContext context)
	{
		_actionMapActive = 0;
		_forkLift.ForkLiftCamOFF();
		_input.Forklift.Disable();
		_input.PlayerMoves.Enable();
	}

	void Update()
	{
		switch(_actionMapActive)
		{
			case 0:
				movePlayer();
				break;

			case 1:
				moveDrone();
				break;

			case 2:
				moveForklift();
				break;
		}
	}

	private void movePlayer()
	{
		Vector2 move;
		move = _input.PlayerMoves.Move.ReadValue<Vector2>();

		_player.Move(move);
	}

	private void moveDrone()
	{
		Vector2 move;
		move = _input.Drone.Moves.ReadValue<Vector2>();
		_drone.DroneMove(move);
	}

	private void moveForklift()
	{
		Vector2 move;
		move = _input.Forklift.Move.ReadValue<Vector2>();
		_forkLift.MoveForklift(move);
	}

	private void Thrust_performed(InputAction.CallbackContext context)
	{
		_drone.Thrust();
	}
}
