using UnityEngine;

/// <summary>
/// Allows the GameObject to flips its sprite horizontally.<br/>
/// 
/// If autoFlip is enabled, then the sprite will automatically flip according to its horizontal speed.<br/>
/// 
/// For this to work, the default sprite of the GameObject has to be facing right.
/// </summary>
public class SpriteFlippable2D : Movable2D
{
	public bool autoFlip = true;
	[SerializeField] private RelativeDirection facing = RelativeDirection.Right;
	[SerializeField] private Transform objectToNotFlip = null;

	protected override void Awake()
	{
		base.Awake();
		Facing = facing;
	}

	// Update is called once per frame
	void Update()
	{
		if (autoFlip)
		{
			if (HSpeed > 0)
				Facing = RelativeDirection.Right;
			else if (HSpeed < 0)
				Facing = RelativeDirection.Left;
		}
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

			if (objectToNotFlip != null)
			{
				float xscale2 = Mathf.Abs(objectToNotFlip.localScale.x);
				if (value == RelativeDirection.Right)
					objectToNotFlip.localScale = new Vector2(xscale2, objectToNotFlip.localScale.y);
				else
					objectToNotFlip.localScale = new Vector2(-xscale2, objectToNotFlip.localScale.y);
			}
		}
	}

	public enum RelativeDirection
	{
		Left, Right
	}
}
