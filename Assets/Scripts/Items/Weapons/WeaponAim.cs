using UnityEngine;

/// <summary>
/// If Ken is holding a weapon, this script rotates it to face the recticle.
/// </summary>
public class WeaponAim : MonoBehaviour
{
	//private readonly GameObject reticlePrefab;
	private Camera cam;
	private Ken ken; // To check and control character movement

	[Header("Bullet starting point")]
	[SerializeField] private Vector2 projectileSpawnPosition;

	public float AimAngle { get; private set; }

	//private GameObject reticle;

	void Awake()
	{
		//Cursor.visible = false;
		cam = Camera.main;
		ken = GetComponentInParent<Ken>();

		//reticle = Instantiate(reticlePrefab);
	}
	
	private void Update()
	{
		if (ken.shooting.HeldWeapon.Weapon == null) // Enable autoflip if Ken is not holding a weapon
		{
			ken.spriteFlippable2D.autoFlip = true;
			return;
		}
		ken.spriteFlippable2D.autoFlip = false; // Ken is holding a weapon, we will flip things manually

		// Calculate angle from Ken to mouse
		Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
		Vector2 lookVector = mousePosition - (Vector2)ken.transform.position;
		float lookAngle = Vector2.SignedAngle(Vector2.right, lookVector);

		// Calculate angle from muzzle to mouse
		Vector2 aimVector = mousePosition - (Vector2)transform.position;
		AimAngle = Vector2.SignedAngle(Vector2.right, aimVector);

		if (lookAngle > 90 || lookAngle < -90)
		{
			ken.spriteFlippable2D.Facing = SpriteFlippable2D.RelativeDirection.Left;
			transform.rotation = Quaternion.Euler(0, 0, AimAngle + 180);
		}
		else
		{
			ken.spriteFlippable2D.Facing = SpriteFlippable2D.RelativeDirection.Right;
			transform.rotation = Quaternion.Euler(0, 0, AimAngle);
		}
	}

	// Get the exact mouse position in order to aim
	//private void GetMousePosition()
	//{
	//	// Get Mouse Position

	//	mousePosition = Input.mousePosition;
	//	mousePosition.z = 5f;  // We set this value to ensure the camera always stays infront to view everything in game

	//	// Get World space position
	//	direction = cam.ScreenToWorldPoint(mousePosition);
	//	direction.z = transform.position.z;
	//	reticlePosition = direction;

	//	currentAimAbsolute = direction - transform.position;

	//	//Debug.Log(ken.Facing);
	//	if (ken.Facing == SpriteFlippable2D.RelativeDirection.Right)
	//	{   //character facing right
	//		currentAim = direction - transform.position;
	//	}
	//	else if (ken.Facing == SpriteFlippable2D.RelativeDirection.Left)
	//	{   //character facing left
	//		currentAim = transform.position - direction;
	//	}
	//}

	//public void RotateWeapon()
	//{
	//	if (currentAim != Vector3.zero && direction != Vector3.zero)
	//	{
	//		// Get Angle
	//		CurrentAimAngle = Mathf.Atan2(currentAim.y, currentAim.x) * Mathf.Rad2Deg;
	//		CurrentAimAngleAbsolute = Mathf.Atan2(currentAimAbsolute.y, currentAimAbsolute.x) * Mathf.Rad2Deg;

	//		CurrentAimAngle = Mathf.Clamp(CurrentAimAngle, -180, 180);

	//		// Apply the angle
	//		lookRotation = Quaternion.Euler(CurrentAimAngle * Vector3.forward);
	//		transform.rotation = lookRotation;

	//		// Check the relative position of the mouse pointer to the character 
	//		if (CurrentAimAngleAbsolute > 90 || CurrentAimAngleAbsolute < -90)
	//		{
	//			//pointing left
	//			ken.Facing = SpriteFlippable2D.RelativeDirection.Left;
	//		}
	//		else
	//		{
	//			//pointing right
	//			ken.Facing = SpriteFlippable2D.RelativeDirection.Right;
	//		}
	//	}
	//	else
	//	{
	//		CurrentAimAngle = 0f;  // If the mouse is not moving at all at the beginning
	//		transform.rotation = initialRotation;
	//	}
	//}

	// Moves our reticle towards our Mouse Position
	//private void MoveReticle()
	//{
	//	reticle.transform.rotation = Quaternion.identity; //set the normal rotation
	//	reticle.transform.position = reticlePosition;
	//}

	// Calculates the position where our projectile is going to be fired
	//public Vector3 EvaluateProjectileSpawnPosition()
	//{
	//	if (ken.Facing == SpriteFlippable2D.RelativeDirection.Right)
	//	{
	//		// Right side
	//		ProjectileSpawnPosition = transform.position + transform.rotation * projectileSpawnPosition;
	//	}
	//	else
	//	{
	//		// Left side
	//		ProjectileSpawnPosition = transform.position - transform.rotation * projectileFlippedSpawnPosition;
	//	}
	//	return ProjectileSpawnPosition;
	//}

	//private void OnDrawGizmosSelected()
	//{
	//	EvaluateProjectileSpawnPosition();

	//	Gizmos.color = Color.green;
	//	Gizmos.DrawWireSphere(ProjectileSpawnPosition, 0.1f);
	//}
}
