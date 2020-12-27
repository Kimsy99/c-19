using UnityEngine;

public class NPCWeaponAim : MonoBehaviour
{
	private GameObject kenCenter;
	private SpriteFlippable2D spriteFlippable2D;

	private StateController stateController;
	[SerializeField] private AIState idleState = null;

	public float AimAngle { get; private set; }

	//private GameObject reticle;

	void Awake()
	{
		kenCenter = GameObject.Find("KenCenter");
		spriteFlippable2D = GetComponentInParent<SpriteFlippable2D>();

		stateController = GetComponentInParent<StateController>();
	}

	void Update()
	{
		if (stateController != null && stateController.currentState == idleState)
		{
			AimAngle = 0;
			return;
		}
		AimAngle = Vector2.SignedAngle(Vector2.right, kenCenter.transform.position - transform.position);
		if (spriteFlippable2D == null || spriteFlippable2D.Facing == SpriteFlippable2D.RelativeDirection.Right)
			transform.rotation = Quaternion.Euler(0, 0, AimAngle);
		else
			transform.rotation = Quaternion.Euler(0, 0, AimAngle + 180);
	}
}
