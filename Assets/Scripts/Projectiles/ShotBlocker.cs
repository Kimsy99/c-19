using UnityEngine;

public class ShotBlocker : Bullet
{
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
			other.gameObject.GetComponentInParent<NPCHealth>().Damage(damage, true);
    }
}
