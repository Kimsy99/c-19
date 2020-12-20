using UnityEngine;

public class ShotBlockerWallCollider : MonoBehaviour
{
	private ShotBlocker shotBlocker;

	void Awake()
	{
		shotBlocker = GetComponentInParent<ShotBlocker>();
	}

	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
			Destroy(shotBlocker.gameObject);
    }
}
