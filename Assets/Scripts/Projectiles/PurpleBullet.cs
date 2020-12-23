using UnityEngine;

public class PurpleBullet : EnemyBullet
{
	[SerializeField] private bool shouldFollow = true;
	[SerializeField] private float moveSpeed = 1;

	public GameObject destroyEffect; //after 2 sec and never touch player, trigger
	public GameObject attackEffect; //if rouch the player, will trigger this effect

	private float lifeTimer;
	[SerializeField] private float maxLife = 2.0F;

	void Update()
	{
		if (shouldFollow)
		{
			Vector2 directionVector = ken.transform.position - transform.position;
			float direction = Vector2.SignedAngle(Vector2.right, directionVector);

			Direction = direction;
			Speed = moveSpeed;
		}

		lifeTimer += Time.deltaTime;
		if (lifeTimer >= maxLife)
		{
			Instantiate(destroyEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	protected override void OnBulletImpact()
	{
		Instantiate(attackEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
