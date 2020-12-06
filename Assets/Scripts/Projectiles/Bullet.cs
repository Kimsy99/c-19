using UnityEngine;

public class Bullet : Movable2D
{
	public GameObject bullet;

	[Header("Effects")]
	[SerializeField] private ParticleSystem impactPS;

	// Should be initialized when created in KenShooting
	public int damage;

	private SpriteRenderer bulletSprite;
	private CircleCollider2D bulletCollider;

    private void Start()
    {
		bulletSprite = GetComponent<SpriteRenderer>();
		bulletCollider = GetComponent<CircleCollider2D>();
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
		
		if(!other.CompareTag("Player"))
        {
			DisableBullet();
			impactPS.Play();
			Invoke(nameof(DestroyBullet), impactPS.main.duration);
		}
    }

	private void DisableBullet()
    {
		Speed = 0;
		//bulletSprite.enabled = false;
		//bulletCollider.enabled = false;
    }
}
