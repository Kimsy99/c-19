using UnityEngine;

public class KenShooting : MonoBehaviour
{
	private KenHealth kenHealth;
	private HeldWeapon heldWeapon;

	public HeldWeapon HeldWeapon => heldWeapon;

	/** Time needed to wait before Ken can shoot the next bullet. */
	[HideInInspector] public float cooldown;

	void Awake()
	{
		kenHealth = GetComponent<KenHealth>();
		heldWeapon = GetComponentInChildren<HeldWeapon>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!LevelManager.Instance.CanPlayerMove)
			return;

		cooldown = Mathf.Max(cooldown - Time.deltaTime, 0);

		if (heldWeapon.Weapon != null)
		{
			if (Input.GetButton("Fire1"))
			{
				if (cooldown == 0)
				{
					cooldown = heldWeapon.WeaponSettings.cooldown;
					heldWeapon.Shoot();
				}
			}
			else
				heldWeapon.DontShoot();
		}
	}
}
