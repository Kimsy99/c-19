using UnityEngine;

public class Turret : NPCHeldWeapon
{
	protected readonly int isActivatedParameter = Animator.StringToHash("IsActivated");
	[SerializeField] private GameObject turretHead = null;
	private bool isActivated;

	protected override void Awake()
	{
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
		}
	}

	public void ToggleTurret()
	{
		turretHead.SetActive(!turretHead.activeSelf);
	}
}
