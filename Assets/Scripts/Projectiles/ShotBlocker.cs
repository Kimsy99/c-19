using UnityEngine;

public class ShotBlocker : Bullet
{
	[SerializeField] protected Transform bulletSpawner;

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void OnCollisionEnter2D(Collision2D other)
	{
	}

	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Boss"))
			other.gameObject.GetComponentInParent<NPCHealth>().Damage(damage, true, 0.1F);
    }
}
