using UnityEngine;
using UnityEngine.UI;

public class NPCHealth : Health
{
	private NPCMovement npcMovement;
	private new Collider2D collider2D;
	private GameObject healthBar;
	private Animator animator;
	private readonly int isDeadParameter = Animator.StringToHash("IsDead");
	private Flashable flashable;

	public Image hpImage;
	public Image hpEffectImage;
	[SerializeField] private float hurtSpeed = 0.005F;

	protected override void Awake()
	{
		base.Awake();
		npcMovement = GetComponent<NPCMovement>();
		collider2D = GetComponent<Collider2D>();
		healthBar = transform.Find("Canvas").gameObject;
		animator = GetComponent<Animator>();
		flashable = GetComponent<Flashable>();

		OnDie += Die;
	}

	protected override void Update()
	{
		base.Update();
		
		hpImage.fillAmount = Hp / maxHp;
		if (hpEffectImage.fillAmount > hpImage.fillAmount)
			hpEffectImage.fillAmount -= hurtSpeed;
		else
			hpEffectImage.fillAmount = hpImage.fillAmount;
	}

	public bool Damage(float damage, bool shouldFlash = false, float invulnerabilityTime = 0)
	{
		bool damaged = base.Damage(damage, invulnerabilityTime);
		if (!damaged)
			return false;
		if (shouldFlash)
			flashable.Flash();
		return true;
	}

	private void Die()
	{
		npcMovement.Speed = 0;
		collider2D.enabled = false;
		healthBar.SetActive(false);
		animator.SetBool(isDeadParameter, true);
		Destroy(gameObject, 10);
		AudioManager.Instance.Play(AudioEnum.EnemyHurt);
	}
}
