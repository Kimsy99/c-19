using UnityEngine;

/// <summary>
/// If Ken is holding a weapon, this script rotates it to face the recticle.
/// </summary>
public class WeaponAim : MonoBehaviour
{
	//private readonly GameObject reticlePrefab;
	private Camera cam;
	private Ken ken; // To check and control character movement

	public float AimAngle { get; private set; }

	//private GameObject reticle;

	void Awake()
	{
		//Cursor.visible = false;
		cam = Camera.main;
		ken = GetComponentInParent<Ken>();

		//reticle = Instantiate(reticlePrefab);
	}
	
	void Update()
	{
		//if (ken.shooting.HeldWeapon.Weapon == null) // Enable autoflip if Ken is not holding a weapon
		//{
		//	ken.spriteFlippable2D.autoFlip = true;
		//	return;
		//}
		//ken.spriteFlippable2D.autoFlip = false; // Ken is holding a weapon, we will flip things manually

		// Calculate angle from Ken to mouse
		Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
		Vector2 lookVector = mousePosition - (Vector2)ken.transform.position;
		float lookAngle = Vector2.SignedAngle(Vector2.right, lookVector);

		// Calculate angle from muzzle to mouse
		Vector2 aimVector = mousePosition - (Vector2)transform.position;
		AimAngle = Vector2.SignedAngle(Vector2.right, aimVector);

		if (ken.health.IsDead || ken.shooting.HeldWeapon.Weapon == null)
			return;
		bool isRotatable = ken.shooting.HeldWeapon.WeaponSettings.isRotatable;
		if (lookAngle > 90 || lookAngle < -90)
		{
			ken.spriteFlippable2D.Facing = SpriteFlippable2D.RelativeDirection.Left;
			transform.rotation = Quaternion.Euler(0, 0, isRotatable ? AimAngle + 180 : 0);
		}
		else
		{
			ken.spriteFlippable2D.Facing = SpriteFlippable2D.RelativeDirection.Right;
			transform.rotation = Quaternion.Euler(0, 0, isRotatable ? AimAngle : 0);
		}
	}
}
