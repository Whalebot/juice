﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlatformerController))]
public class PlayerInputModule : MonoBehaviour
{
	PlatformerController controller;

	void Start ()
	{
		controller = GetComponent<PlatformerController> ();
	}

	void Update ()
	{
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if (input.magnitude > 1)
		{
			input.Normalize();
		}
		controller.input = input;
        if (Input.GetButtonDown("Jump"))
        {
			controller.inputJump = true;
		}

	}
}
