using UnityEngine;

public class KenMovement : AnimatableMovable2D
{
	[SerializeField] private float walkSpeed = 5;
	public float speedMultiplier = 1;

	public Vector2 recoilVelocity = new Vector2(0, 0);

	private Animator weaponHolderAnimator;

	protected override void Awake()
	{
		base.Awake();
		weaponHolderAnimator = GameObject.Find("WeaponHolder").GetComponent<Animator>();
	}

	// Update is called once per frame
	protected override void Update()
	{

		float vx = Input.GetAxisRaw("Horizontal");
		float vy = Input.GetAxisRaw("Vertical");

		float speed = speedMultiplier * walkSpeed * (Input.GetKey(KeyCode.LeftShift) ? 2 : 1);
		animator.SetBool(isMovingParamater, IsWalking());
		weaponHolderAnimator.SetBool(isMovingParamater, IsWalking());

		SetVelocity(recoilVelocity.x + vx * speed, recoilVelocity.y + vy * speed);
	}

	public bool IsWalking()
	{
		float vx = Input.GetAxisRaw("Horizontal");
		float vy = Input.GetAxisRaw("Vertical");
		return vx != 0 || vy != 0;
	}
}
