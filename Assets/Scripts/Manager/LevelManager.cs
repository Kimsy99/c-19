using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
	private Ken ken;
	private HeldWeapon heldWeapon;
	private Transform bulletSpawner;
	[SerializeField] private WeaponSettings firstWeaponSettings = null;
	[SerializeField] private WeaponSettings secondWeaponSettings = null;
	[SerializeField] private WeaponSettings thirdWeaponSettings = null;

	[SerializeField] private GameObject flashLight = null;

	public bool isBossIntro, isBossReady;

	protected override void Awake()
	{
		base.Awake();
		ken = GameObject.Find("Ken").GetComponent<Ken>();
		heldWeapon = ken.GetComponentInChildren<HeldWeapon>();
		bulletSpawner = ken.transform.Find("WeaponHolder").Find("BulletSpawner");
	}

	void Start()
	{
		Weapon firstWeapon = new Weapon(firstWeaponSettings);
		InventoryManager.Instance.SetWeapon(0, firstWeapon);
		InventoryManager.Instance.SetWeapon(1, new Weapon(secondWeaponSettings));
		InventoryManager.Instance.SetWeapon(2, new Weapon(thirdWeaponSettings));
		heldWeapon.SetHeldWeapon(firstWeapon);

		AudioManager.Instance.Play(AudioEnum.Level4Theme);
	}

	public void SetFlashLightEnabled(bool isEnabled)
	{
		Instantiate(flashLight, bulletSpawner);
	}
}
