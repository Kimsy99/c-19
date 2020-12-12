using UnityEngine;

public class Bullet : Movable2D
{
	public GameObject bullet;

	[Header("Effects")]
	[SerializeField] private ParticleSystem impactPS;
	[SerializeField] private ParticleSystem impactPS2;

	// Should be initialized when created in KenShooting
	private float damage;

	private SpriteRenderer spriteRenderer;
	private CircleCollider2D bulletCollider;

	private string ownerTag;

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

	public void SetOwnerTag(string tag)
    {
		ownerTag = tag;
    }

    void OnBecameInvisible()
	{
		DestroyBullet();
	}

	private void DestroyBullet()
    {
		Destroy(bullet);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		// Collide with everything except object of its type
		if (!other.CompareTag(ownerTag))
        {
			impactPS.Play();
			if (impactPS2 != null)
				impactPS2.Play();

			// Wait for particle finish playing
			Invoke(nameof(DestroyBullet), impactPS.main.duration);

			if (other.CompareTag("NPC"))
            {
				other.gameObject.GetComponent<Flashable>().Flash();
				other.gameObject.GetComponentInChildren<NPCHealthBar>().hp -= damage;
				// make damage to character being shot
				//other.GetComponent<KenHealth>().Damage(damage);
            }
			DisableBullet();
		}
    }

	private void DisableBullet()
    {
		print("disable");
		Direction = 90;
		Speed = 0;
		spriteRenderer.sprite = null;
		bulletCollider.enabled = false;
    }
}
