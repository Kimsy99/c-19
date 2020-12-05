using UnityEngine;

/// <summary>
/// Flips the sprite of the GameObject to the left/right according to its horizontal speed.
/// 
/// For this to work, the default sprite of the GameObject has to be facing right.
/// </summary>
public class SpriteFlippable2D : Movable2D
{
	private RelativeDirection facing = RelativeDirection.Right;

	// Update is called once per frame
	void Update()
	{
		float xscale = Mathf.Abs(transform.localScale.x);
		if (HSpeed > 0)
			Facing = RelativeDirection.Right;
		else if (HSpeed < 0)
			Facing = RelativeDirection.Left;
	}

	/// <summary>
	/// Facing property. The direction that the sprite of the GameObject is facing.
	/// </summary>
	public RelativeDirection Facing
	{
		get => facing;
		set
		{
			facing = value;
			float xscale = Mathf.Abs(transform.localScale.x);
			if (value == RelativeDirection.Right)
				transform.localScale = new Vector2(xscale, transform.localScale.y);
			else
				transform.localScale = new Vector2(-xscale, transform.localScale.y);
		}
	}

	public enum RelativeDirection
	{
		Left, Right
	}
}
