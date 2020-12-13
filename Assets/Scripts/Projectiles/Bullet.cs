using UnityEngine;

public class Bullet : Movable2D
{
	[Header("Effects")]
	[SerializeField] private ParticleSystem impactPS;
	[SerializeField] private ParticleSystem impactPS2;

	// Should be initialized when created in KenShooting
	protected float damage;

	private SpriteRenderer spriteRenderer;
	private CircleCollider2D bulletCollider;

	public string ShotByWeaponName { get; set; }

    protected override void Awake()
    {
		base.Awake();
		spriteRenderer = GetComponent<SpriteRenderer>();
		bulletCollider = GetComponent<CircleCollider2D>();
    }

	public void SetDamage(float damage)
    {
		this.damage = damage;
    }

    void OnBecameInvisible()
	{
		DestroyBullet();
	}

	private void DestroyBullet()
    {
		Destroy(gameObject);
	}

	protected virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (ShotByWeaponName.Equals("Shot Blocker"))
			return;

		impactPS.Play();
		if (impactPS2 != null)
			impactPS2.Play();

		// Wait for particle finish playing
		Invoke(nameof(DestroyBullet), impactPS.main.duration);

		if (other.CompareTag("NPC"))
        {
			other.gameObject.GetComponent<Flashable>()?.Flash();
			other.gameObject.GetComponentInChildren<NPCHealthBar>().hp -= damage;
			// make damage to character being shot
			//other.GetComponent<KenHealth>().Damage(damage);
        }
		DisableBullet();
    }

	protected void DisableBullet()
    {
		Direction = 90;
		Speed = 0;
		spriteRenderer.sprite = null;
		bulletCollider.enabled = false;
    }
}
