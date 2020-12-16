using UnityEngine;

public class FollowEnemyProjectile : EnemyBullet
{
	[SerializeField] private float moveSpeed = 1;

	public GameObject destroyEffect; //after 2 sec and never touch player, trigger
	public GameObject attackEffect; //if rouch the player, will trigger this effect

	private float lifeTimer;
	[SerializeField] private float maxLife = 2.0F;

	private void Update()
	{
		Vector2 directionVector = ken.transform.position - transform.position;
		float direction = Vector2.SignedAngle(Vector2.right, directionVector);

		Direction = direction;
		Speed = moveSpeed;

		lifeTimer += Time.deltaTime;
		if (lifeTimer >= maxLife)
		{
			Instantiate(destroyEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	//projectile collide with player
	protected override void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
			ken.health.Damage(damage, true, 0.1F);
		Instantiate(attackEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}