using UnityEngine;

public class Health : MonoBehaviour
{
	private float hp;
	[SerializeField] protected float maxHp;
	public bool isInvulnerable;

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

	public virtual bool Damage(float damage)
	{
		if (!isInvulnerable)
		{
			Hp -= damage;
			return true;
		}
		return false;
	}

	public bool IsDead()
	{
		return Hp == 0;
	}

	public virtual void Die() {}
}
