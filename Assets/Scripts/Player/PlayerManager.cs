using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	private GameInputActions _input;

	[SerializeField] private Player _player;

	void Start()
	{
		_input = new GameInputActions();
		_input.Enable();
	}

    void Update()
	{
		Vector2 move;
		move = _input.PlayerMoves.Move.ReadValue<Vector2>();

		_player.Move(move);
	}
}
