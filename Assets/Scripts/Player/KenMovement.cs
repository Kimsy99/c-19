using UnityEngine;

public class KenMovement : AnimatableMovable2D
{
	[SerializeField] private float walkSpeed = 5;
	public float speedMultiplier = 1;

	[SerializeField] private Vector2 recoilVelocity = new Vector2(0, 0);
	[SerializeField] private float recoilFriction = 10;

	private Animator weaponHolderAnimator;

	protected override void Awake()
	{
		base.Awake();
		weaponHolderAnimator = transform.Find("WeaponHolder").GetComponent<Animator>();
	}

	// Update is called once per frame
	protected override void Update()
	{
		// Handle other movement
		// Apply friction to recoil
		recoilVelocity = recoilVelocity.normalized * Mathf.Max(recoilVelocity.magnitude - recoilFriction * Time.deltaTime, 0);

		// Handle user movement
		float vx = Input.GetAxisRaw("Horizontal");
		float vy = Input.GetAxisRaw("Vertical");

		float speed = speedMultiplier * walkSpeed; //* (Input.GetKey(KeyCode.LeftShift) ? 2 : 1);
		if (LevelManager.Instance.CanPlayerMove)
			speed = 0;
		animator.SetBool(isMovingParamater, IsWalking());
		weaponHolderAnimator.SetBool(isMovingParamater, IsWalking());
		
		SetVelocity(recoilVelocity.x + vx * speed, recoilVelocity.y + vy * speed);
	}

	public bool IsWalking()
	{
		if (LevelManager.Instance.CanPlayerMove)
			return false;
		float vx = Input.GetAxisRaw("Horizontal");
		float vy = Input.GetAxisRaw("Vertical");
		return vx != 0 || vy != 0;
	}

	public void RecoilFrom(Transform other)
	{
		recoilVelocity = (transform.position - other.position).normalized * 5;
	}
}
