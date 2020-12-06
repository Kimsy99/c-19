using UnityEngine;

public class Bullet : Movable2D
{
	public GameObject bullet;

	[Header("Effects")]
	[SerializeField] private ParticleSystem impactPS;

	void OnCollisionEnter2D(Collision2D collision)
	{

	}

	void OnBecameInvisible()
	{
		Destroy(bullet);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        /*Debug.Log("colided");
        impactPS.Play();*/
    }

}
