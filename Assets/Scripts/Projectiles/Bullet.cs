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

    void OnBecameInvisible()
	{
		Destroy(bullet);
	}

	private void DestroyBullet()
    {
		Destroy(bullet);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(ownerTag == null)
        {
			// the bullet will collide with shooter when created
			ownerTag = other.tag;
			return;
        }
		// collide with everything except object of its type
		if(!other.CompareTag(ownerTag))
        {
			Debug.Log(ownerTag);
			DisableBullet();
			impactPS.Play();
			// Wait for particle finish playing
			Invoke(nameof(DestroyBullet), impactPS.main.duration);

			if(other.CompareTag("Player") || other.CompareTag("NPC"))
            {
				// make damage to character being shot
				Debug.Log("make damage " + damage);
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
