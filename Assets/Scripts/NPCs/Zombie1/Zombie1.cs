using System;
using UnityEngine;

[Obsolete("No longer required, use NPCMovement script as component instead")]
public class Zombie1 : NPCMovement
{
	//private readonly int isAttack = Animator.StringToHash("isAttack");
	[SerializeField] private GameObject projectile = null; //projectile Object
	
	protected override void Awake()
	{
		base.Awake();
		//target = GameObject.FindWithTag("Player").transform;
	}

	// Update is called once per frame
	//protected override void Update()
	//{
	//	base.Update();
	//	//player outside the range
	//	if (Vector2.Distance(transform.position, target.position) >= attackRange)
	//	{
	//		//Debug.Log("No player");
	//		//animator.SetBool(isAttack, value: false);
	//		// Patrol(attackRange);
	//	}
	//	else
	//	{
	//		//animator.SetBool(isAttack, value: true);
	//		// Shot();
	//		//Debug.Log("Found player");
	//	}
	//	Patrol(attackRange);
	//	//test minus life point
	//	//if (Input.GetKeyDown(KeyCode.Space))
	//	//{
	//	//	GetComponentInChildren<NPCHealth>().Damage(25);
	//	//}
	//}

	protected override void Patrol(float followRange)
	{
		//movement

		// wayPointTarget = wayPoint01;
		// transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime);
		//if (Vector2.Distance(transform.position, target.position) <= followRange)
		//{
		//	wayPointTarget = target.position;
		//	print("go to target");
		//}
		//else
		//{
		//	//if (wayPointTarget == (Vector2)target.position)
		//	//	wayPointTarget = wayPoint02.position;
		//	if (wayPoint01 != null && wayPoint02 != null)
		//	{
		//		print("both waypoint not null");
		//		if (Vector2.Distance(transform.position, wayPoint01.position) <= 0.1F)
		//		{
		//			wayPointTarget = wayPoint02.position;
		//			print("go to way point 2");
		//		}
		//		else if (Vector2.Distance(transform.position, wayPoint02.position) <= 0.1F)
		//		{
		//			wayPointTarget = wayPoint01.position;
		//			print("go to way point 1");
		//		}
		//	}
		//	else
		//	{
		//		wayPointTarget = initialPosition;
		//		print("go to innitial");
		//	}

		//}
		//// transform.direction
		////controller
		//Vector2 nextPosition = wayPointTarget - (Vector2)transform.position;
		//Vector2 direction = nextPosition - (Vector2)transform.position;
		//float angle = Vector2.SignedAngle(Vector2.right, direction);

		//print(Vector2.Distance(transform.position, initialPosition));
		//if (wayPoint01 != null && wayPoint02 != null && Vector2.Distance(transform.position, initialPosition) <= 0.1F) // Initial position mode
		//	Speed = 0;
		//else
		//{
		//	Direction = angle;
		//	Speed = walkSpeed;
		//}
	}

	public void Shot()
	{
		Instantiate(projectile, transform.position, Quaternion.identity);
	}
  
  // protected void Patrol(float attackRange)
  // {
  //   //movement
  //   Vector2 nextPosition = Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime);
  //   // wayPointTarget = wayPoint01;
  //   // transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime);
  //   if (Vector2.Distance(transform.position, target.position) <= attackRange)
  //   {
  //     wayPointTarget = target;
  //   }
  //   else
  //   {
  //     if (wayPointTarget == target)
  //     {
  //       wayPointTarget = wayPoint02;
  //     }
  //     if (Vector2.Distance(transform.position, wayPoint01.position) <= 0.1f)
  //     {
  //       wayPointTarget = wayPoint02;
  //     }
  //     if (Vector2.Distance(transform.position, wayPoint02.position) <= 0.1f)
  //     {
  //       wayPointTarget = wayPoint01;
  //     }
  //   }
  //   // transform.direction
  //   //controller
  //   Vector2 direction = nextPosition - (Vector2)transform.position;
  //   float angle = Vector2.SignedAngle(Vector2.right, direction);

  //   // Debug.Log(Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime));


  //   // vx = Input.GetAxisRaw("Horizontal");
  //   // vy = Input.GetAxisRaw("Vertical");
  //   // Debug.Log(-(transform.position.x - nextPosition.x) * 10 + " " + -(transform.position.y - nextPosition.y) * 10);
  //   Direction = angle;
  //   Speed = walkSpeed;
  //   // SetVelocity(vx * walkSpeed, vy * walkSpeed);

  //   // SetVelocity(vx * walkSpeed, vy * walkSpeed);
  //   // SetVelocity(-(transform.position.x - nextPosition.x) * 7 * walkSpeed, (-(transform.position.y - nextPosition.y) * 7) * walkSpeed);
  //   // UpdateAnimations();

  // }
  // public void Shot()
  // {
  //   Instantiate(projectile, transform.position, Quaternion.identity);
  // }
}
