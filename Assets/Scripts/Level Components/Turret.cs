using UnityEngine;

public class Turret : NPCHeldWeapon
{
	private Ken ken;

	protected readonly int isActivatedParameter = Animator.StringToHash("IsActivated");
	[SerializeField] private GameObject turretHead = null;
	private bool isActivated;

	[SerializeField] private bool shouldAutoShoot = false;

	protected override void Awake()
	{
		ken = GameObject.Find("Ken").GetComponent<Ken>();

		animator = GetComponent<Animator>();
		animator.Play("TurretDeactivating", 0, 1);
	}

	//private void Update()
	//{
	//	if (Input.GetKeyDown(KeyCode.C))
	//		Shoot();
	//}

	public bool Activated
	{
		get => isActivated;
		set
		{
			isActivated = value;
			AudioManager.Instance.Play(AudioEnum.TurretActivating);
			animator.SetBool(isActivatedParameter, value);

			if (shouldAutoShoot)
			{
				if (value)
					InvokeRepeating(nameof(ShootIfNearby), 1.5F + Random.Range(0, 0.5F), 0.5F);
				else
					CancelInvoke(nameof(ShootIfNearby));
			}
		}
	}

	public void ToggleTurret()
	{
		turretHead.SetActive(!turretHead.activeSelf);
	}

	public void ShootIfNearby()
	{
		if (((Vector2)(ken.center.position - transform.position)).sqrMagnitude < 7.5F * 7.5F)
		{
			AudioManager.Instance.PlayOneShot(AudioEnum.TurretShoot);
			Shoot();
		}
	}
}
