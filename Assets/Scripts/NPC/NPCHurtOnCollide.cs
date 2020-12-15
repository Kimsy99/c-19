using UnityEngine;

public class NPCHurtOnCollide : MonoBehaviour
{
	private Ken ken;
	private bool isHurtingKen;
	[SerializeField] private float collisionDamage = 0.5F;

	void Awake()
	{
		ken = GameObject.Find("Ken").GetComponent<Ken>();
	}

	void Update()
	{
		if (isHurtingKen)
		{
			ken.movement.RecoilFrom(transform);
			ken.health.Damage(collisionDamage, true, 0.25F);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
			isHurtingKen = true;
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
			isHurtingKen = false;
	}
}
