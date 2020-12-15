using UnityEngine;

public class FollowEnemyProjectile : MonoBehaviour
{
	private Transform target;
	[SerializeField] private float moveSpeed = 1;

	public GameObject destroyEffect; //after 2 sec and never touch player, trigger
	public GameObject attackEffect; //if rouch the player, will trigger this effect

	private float lifeTimer;
	[SerializeField] private float maxLife = 2.0F;

	private void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	private void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

		lifeTimer += Time.deltaTime;
		if (lifeTimer >= maxLife)
		{
			Instantiate(destroyEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	//projectile collide with player
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			// other.GetComponentInChildren<NPCHealthBar>().hp -= 25;
			Instantiate(attackEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}