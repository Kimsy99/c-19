using UnityEngine;

public class Bullet : Movable2D
{
	public GameObject bullet;

	[Header("Effects")]
	[SerializeField] private ParticleSystem impactPS;

	// Should be initialized when created in KenShooting
	private int damage;

	private SpriteRenderer bulletSprite;
	private CircleCollider2D bulletCollider;

	private string ownerTag;

    private void Start()
    {
		bulletSprite = GetComponent<SpriteRenderer>();
		bulletCollider = GetComponent<CircleCollider2D>();
    }

	public void setDamage(int damageValue)
    {
		damage = damageValue;
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
		// collide with everything except object of its type
		if(!other.CompareTag(ownerTag))
        {
			DisableBullet();
			impactPS.Play();
			// Wait for particle finish playing
			Invoke(nameof(DestroyBullet), impactPS.main.duration);

			if(other.CompareTag("Player") || other.CompareTag("NPC"))
            {
				// make damage to character being shot
				other.GetComponent<KenHealth>().Damage(damage);
            }
		}
    }

	private void DisableBullet()
    {
		Speed = 0;
		//bulletSprite.enabled = false;
		bulletCollider.enabled = false;
    }
}
