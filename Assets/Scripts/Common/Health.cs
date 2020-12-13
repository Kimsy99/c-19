using UnityEngine;

public class Health : MonoBehaviour
{
	private float hp;
	[SerializeField] protected float maxHp;
	public float invulnerabilityTimer = 0;

	public virtual float Hp
	{
		get => hp;
		set
		{
			hp = Mathf.Clamp(value, 0, maxHp);
			if (hp == 0)
				Die();
		}
	}

	// Use this for initialization
	protected virtual void Awake()
	{
		Hp = maxHp;
	}

	protected virtual void Update()
	{
		invulnerabilityTimer = Mathf.Max(invulnerabilityTimer - Time.deltaTime, 0);
	}

	public virtual bool Damage(float damage)
	{
		if (!IsInvulnerable)
		{
			Hp -= damage;
			return true;
		}
		return false;
	}

	public bool IsInvulnerable
	{
		get => invulnerabilityTimer > 0;
	}

	public bool IsDead
	{
		get => Hp == 0;
	}

	public virtual void Die() {}
}
