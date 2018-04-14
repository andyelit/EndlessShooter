﻿using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";

	public InputVector2Event onMovementInput = new InputVector2Event ();

	private void Update ()
	{
		var input = new Vector2 (Input.GetAxisRaw (horizontalAxis), Input.GetAxisRaw (verticalAxis));
		input = Vector2.ClampMagnitude (input, 1f);

		onMovementInput.Invoke (input);
	}
}