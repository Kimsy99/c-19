﻿using UnityEngine;

public class NPCMovement : AnimatableMovable2D
{
	private NPCHealth npcHealth;

	protected Vector2 initialPosition;
	public Transform wayPoint01, wayPoint02;
	protected Vector2 wayPointTarget;
	[SerializeField] private float followRange = 10;
	[SerializeField] protected float walkSpeed = 4;
	//private Transform target;

	protected override void Awake()
	{
		base.Awake();
		initialPosition = transform.position;
		print(initialPosition);
		npcHealth = GetComponent<NPCHealth>();
		//wayPointTarget = wayPoint01.position;
		//target = GameObject.FindWithTag("Player").transform;
	}

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();
		if (npcHealth.IsDead)
			return;
		Patrol(followRange);
	}

	protected virtual void Patrol(float followRange)
	{
		//movement
		//Vector2 nextPosition = Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime);
		// wayPointTarget = wayPoint01;
		// transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime);
		//if (Vector2.Distance(transform.position, wayPoint01.position) <= 0.1f)
		//{
		//	wayPointTarget = wayPoint02;
		//}
		//if (Vector2.Distance(transform.position, wayPoint02.position) <= 0.1f)
		//{
		//	wayPointTarget = wayPoint01;
		//}
		// transform.direction
		//controller
		//Vector2 direction = nextPosition - (Vector2)transform.position;
		//float angle = Vector2.SignedAngle(Vector2.right, direction);

		// Debug.Log(Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime));


		// vx = Input.GetAxisRaw("Horizontal");
		// vy = Input.GetAxisRaw("Vertical");
		// Debug.Log(-(transform.position.x - nextPosition.x) * 10 + " " + -(transform.position.y - nextPosition.y) * 10);
		//Direction = angle;
		//Speed = walkSpeed;
		// SetVelocity(vx * walkSpeed, vy * walkSpeed);

		// SetVelocity(vx * walkSpeed, vy * walkSpeed);
		// SetVelocity(-(transform.position.x - nextPosition.x) * 7 * walkSpeed, (-(transform.position.y - nextPosition.y) * 7) * walkSpeed);
		// UpdateAnimations();

	}
	// private void UpdateAnimations()
	// {
	//   if (Mathf.Abs(vx) > 0.1f || Mathf.Abs(vy) > 0.1f)
	//   {
	//     animator.SetBool(movingParamater, value: true);
	//   }
	//   else
	//   {
	//     animator.SetBool(movingParamater, value: false);
	//   }
	// }

}


