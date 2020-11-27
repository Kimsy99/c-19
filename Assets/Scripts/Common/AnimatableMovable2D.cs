﻿using UnityEngine;

public class AnimatableMovable2D : Movable2D
{
	private Animator animator;
	private readonly int movingParamater = Animator.StringToHash("Moving");

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (Speed > 0)
			animator.SetBool(movingParamater, value: true);
		else
			animator.SetBool(movingParamater, value: false);
	}
}
