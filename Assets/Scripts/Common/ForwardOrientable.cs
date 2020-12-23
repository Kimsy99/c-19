using UnityEngine;

/// <summary>
/// Makes it such that the sprite will always face the direction that it is going.<br/>
/// 
/// For this to work properly, the GameObject's sprite must be facing to the right and does not have
/// the SpriteFlippable2D component.
/// </summary>
public class ForwardOrientable : Movable2D
{
	void Update()
	{
		transform.localRotation = Quaternion.Euler(0, 0, Direction);
	}
}
