using UnityEngine;

public class Collectable : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private ParticleSystem collectEffect = null;
	[SerializeField] private bool shouldDestroy = true;

	protected Ken ken;

	protected virtual void Awake()
	{
		ken = FindObjectOfType<Ken>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (Vector2.Distance(ken.center.position, transform.position) < 1.2F)
			{
				if (collectEffect != null)
					Instantiate(collectEffect, transform.position, Quaternion.identity);
				Collect();
				if (shouldDestroy)
					Destroy(gameObject);
			}
		}
	}

	protected virtual void Collect() {}
}
