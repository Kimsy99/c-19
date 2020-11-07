using UnityEditor;
using UnityEngine;

/**
 * For all GameObjects that are able to move in a specified direction and speed.
 */
public class Movable2D : MonoBehaviour
{
	private const float floatThreshold = 0.0001F;

	/** Cached direction the GameObject is moving, in degrees. 0 means to the right and increases anti-clockwise. */
	private float direction;
	/** Whether the GameObject is moving backwards. */
	private bool isMovingBackwards;

	protected Rigidbody2D body;

	// Start is called before the first frame update
	void Awake()
	{
		body = GetComponent<Rigidbody2D>();
	}

	/**
	 * Speed property. The speed the GameObject is moving in units per second, negative means backwards.
	 * 
	 * Changing Speed scales HSpeed and VSpeed, but does not change Direction.
	 */
	public float Speed
	{
		get
		{
			float vx = body.velocity.x, vy = body.velocity.y;
			return Mathf.Sqrt(vx * vx + vy * vy);
		}
		set
		{
			isMovingBackwards = value < 0;
			float vx = value * Mathf.Cos(Direction * Mathf.Deg2Rad), vy = value * Mathf.Sin(Direction * Mathf.Deg2Rad); //Final velocity
			SetVelocity(vx, vy);
		}
	}

	/**
	 * Direction property. The direction this GameObject is moving, in degrees. 0 means to the right and increases
	 * anti-clockwise.
	 * 
	 * Changing Direction changes HSpeed and VSpeed, but does not change Speed.
	 */
	public float Direction
	{
		get
		{
			if (Mathf.Abs(Speed) > floatThreshold)
				direction = Vector2.SignedAngle(Vector2.right, body.velocity);
			if (isMovingBackwards)
			{
				if (direction > 0)
					direction -= 180;
				else
					direction += 180;
			}
			return direction;
		}
		set
		{
			direction = value;
			SetVelocity(Speed * Mathf.Cos(direction*Mathf.Deg2Rad), Speed * Mathf.Sin(direction*Mathf.Deg2Rad));
		}
	}

	/**
	 * HSpeed property. Refers to the horizontal speed this GameObject is moving in units per second. Positive means
	 * to the right, and negative means to the left.
	 * 
	 * Changing HSpeed changes Direction and Speed, but does not change VSpeed.
	 */
	public float HSpeed
	{
		get => body.velocity.x;
		set => SetVelocity(value, VSpeed);
	}

	/**
	 * VSpeed property. Refers to the vertical speed this GameObject is moving. Positive means upwards, and negative
	 * means downwards.
	 * 
	 * Changing VSpeed changes Direction and Speed, but does not change HSpeed.
	 */
	public float VSpeed
	{
		get => body.velocity.y;
		set => SetVelocity(HSpeed, value);
	}

	/**
	 * Sets the velocity of this GameObject, in units per second.
	 * Params:
	 * vx - horizontal velocity
	 * vy - vertical velocity
	 */
	public void SetVelocity(float vx, float vy)
	{
		float dMomentumX = body.mass * (vx - body.velocity.x);
		float dMomentumY = body.mass * (vy - body.velocity.y);
		body.AddForce(new Vector2(dMomentumX, dMomentumY), ForceMode2D.Impulse);
	}
}
