using UnityEngine;

/// <summary>
/// Flips the sprite of the GameObject to the left/right according to its horizontal speed.
/// </summary>
public class SpriteFlippable2D : Movable2D
{
	// Update is called once per frame
	void Update()
	{
		float xscale = Mathf.Abs(transform.localScale.x);
		if (HSpeed > 0)
			transform.localScale = new Vector2(xscale, transform.localScale.y);
		else if (HSpeed < 0)
			transform.localScale = new Vector2(-xscale, transform.localScale.y);
	}
}
