using UnityEngine;

public class KenMovement : AnimatableMovable2D
{
	[SerializeField] private float walkSpeed = 5;
	public float speedMultiplier = 1;

	public Vector2 recoilVelocity = new Vector2(0, 0);

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();

		float vx = Input.GetAxisRaw("Horizontal");
		float vy = Input.GetAxisRaw("Vertical");

		float speed = speedMultiplier * walkSpeed * (Input.GetKey(KeyCode.LeftShift) ? 2 : 1);

		SetVelocity(recoilVelocity.x + vx * speed, recoilVelocity.y + vy * speed);
	}
}
