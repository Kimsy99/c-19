using UnityEngine;

public class EnemyBullet : Bullet
{
	[SerializeField] protected float infectionRate = 0;
	protected Ken ken;

	protected override void Awake()
	{
		base.Awake();
		ken = GameObject.Find("Ken").GetComponent<Ken>();
	}

	protected void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			ken.health.Damage(damage, true, 0.1F);
			ken.health.Infect(infectionRate);
		}

		OnBulletImpact();
	}

	protected override void OnCollisionEnter2D(Collision2D other)
	{
		OnBulletImpact();
	}
}
