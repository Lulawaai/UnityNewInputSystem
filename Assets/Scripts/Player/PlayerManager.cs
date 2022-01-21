using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerManager : MonoBehaviour
{
	private GameInputActions _input;

	[SerializeField] private Player _player;
	[SerializeField] private Drone _drone;

	[SerializeField] private bool _isPlayerInput = true;

	void Start()
	{
		_input = new GameInputActions();
		_input.Enable();
		_input.PlayerMoves.Enable();
		_input.PlayerMoves.DroneSwitch.performed += DroneSwitch_performed;
		_input.Drone.Disable();
		_input.Drone.PlayerSwitch.performed += PlayerSwitch_performed;
	}

	private void PlayerSwitch_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
	{
		_isPlayerInput = true;
		_drone.CameraDroneOn(_isPlayerInput);
		_input.PlayerMoves.Enable();
		_input.Drone.Disable();
	}

	private void DroneSwitch_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
	{
		_isPlayerInput = false;
		_drone.CameraDroneOn(_isPlayerInput);
		_input.PlayerMoves.Disable();
		_input.Drone.Enable();
	}

	void Update()
	{
		if (_isPlayerInput == true)
		{
			movePlayer();
		}
		else
			moveDrone();
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
}
