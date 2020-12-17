using UnityEngine;

public class Bullet : Movable2D
{
	[Header("Effects")]
	[SerializeField] protected ParticleSystem impactPS;
	[SerializeField] protected ParticleSystem impactPS2;

	// Should be initialized when created in KenShooting
	protected float damage;

	private SpriteRenderer spriteRenderer;
	private Collider2D bulletCollider;

	public string ShotByWeaponName { get; set; }

    protected override void Awake()
    {
		base.Awake();
		spriteRenderer = GetComponent<SpriteRenderer>();
		bulletCollider = GetComponent<BoxCollider2D>();
    }

	public void SetDamage(float damage)
    {
		this.damage = damage;
    }

	protected virtual void OnCollisionEnter2D(Collision2D other)
	{
		if (ShotByWeaponName.Equals("Shot Blocker"))
			return;

		if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
			other.gameObject.GetComponentInParent<NPCHealth>().Damage(damage, true);

		OnBulletImpact();
	}

	void OnBecameInvisible()
	{
		DestroyBullet();
	}

	protected virtual void OnBulletImpact()
	{
		if (impactPS != null)
			impactPS.Play();
		if (impactPS2 != null)
			impactPS2.Play();

		// Wait for particle finish playing
		Invoke(nameof(DestroyBullet), impactPS.main.duration);
		DisableBullet();
	}

	protected void DisableBullet()
	{
		Direction = 0;
		Speed = 0;
		spriteRenderer.sprite = null;
		bulletCollider.enabled = false;
	}

	protected void DestroyBullet()
	{
		Destroy(gameObject);
	}
}
