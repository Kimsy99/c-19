﻿using UnityEngine;

/**
 * Makes it such that the sprite will always face the direction that it is going.
 * 
 * For this to work properly, the GameObject's sprite must be facing to the right and does not have
 * the SpriteFlippable2D component.
 */
public class ForwardOrientable : Movable2D
{
	void Update()
	{
		transform.localRotation = Quaternion.Euler(0, 0, Direction);
	}
}
