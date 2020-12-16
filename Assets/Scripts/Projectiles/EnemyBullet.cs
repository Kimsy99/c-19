using UnityEngine;

public class EnemyBullet : Bullet
{
	protected Ken ken;

	protected override void Awake()
	{
		base.Awake();
		ken = GameObject.Find("Ken").GetComponent<Ken>();
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		impactPS.Play();
		if (impactPS2 != null)
			impactPS2.Play();

		// Wait for particle finish playing
		Invoke(nameof(DestroyBullet), impactPS.main.duration);

		DisableBullet();

		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
			ken.health.Damage(damage, true, 0.1F);
	}

	protected override void OnCollisionEnter2D(Collision2D other)
	{
		impactPS.Play();
		if (impactPS2 != null)
			impactPS2.Play();

		// Wait for particle finish playing
		Invoke(nameof(DestroyBullet), impactPS.main.duration);

		DisableBullet();
	}
}
