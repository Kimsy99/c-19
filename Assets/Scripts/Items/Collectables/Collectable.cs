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
		if (!LevelManager.Instance.CanPlayerMove)
			return;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (Vector2.Distance(ken.center.position, transform.position) < 1.2F && CanCollect())
			{
				if (collectEffect != null)
					Instantiate(collectEffect, transform.position, Quaternion.identity);
				Collect();
				if (shouldDestroy)
					Destroy(gameObject);
			}
		}
	}

	private bool CanCollect()
	{
		Vector2 directionVector = transform.position - ken.center.position;
		float distance = Vector2.Distance(ken.center.position, transform.position);
		RaycastHit2D hit = Physics2D.Raycast(ken.center.position, directionVector, distance, LayerMask.GetMask("Wall"));
		return !hit || hit.collider.gameObject.GetComponent<Chest>() != null;
	}

	protected virtual void Collect() {}
}
