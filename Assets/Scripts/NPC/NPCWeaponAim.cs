using UnityEngine;

public class NPCWeaponAim : MonoBehaviour
{
	private GameObject kenCenter;
	private SpriteFlippable2D spriteFlippable2D;

	public float AimAngle { get; private set; }

	//private GameObject reticle;

	void Awake()
	{
		kenCenter = GameObject.Find("KenCenter");
		spriteFlippable2D = GetComponentInParent<SpriteFlippable2D>();
	}

	void Update()
	{
		AimAngle = Vector2.SignedAngle(Vector2.right, kenCenter.transform.position - transform.position);
		if (spriteFlippable2D == null || spriteFlippable2D.Facing == SpriteFlippable2D.RelativeDirection.Right)
			transform.rotation = Quaternion.Euler(0, 0, AimAngle);
		else
			transform.rotation = Quaternion.Euler(0, 0, AimAngle + 180);
	}
}
