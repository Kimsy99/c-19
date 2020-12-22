using UnityEngine;

public class TerminalLaser : TerminalWarningLaser
{
	[SerializeField] private float damage = 1.5F;
	private bool hasHit = false;

	protected override void Update()
	{
		lineRenderer.widthMultiplier = Random.Range(widthMin, widthMax);
		ShootLaser(LayerMask.GetMask("Wall", "Player"), direction);
	}

	protected override void OnLaserHit(RaycastHit2D hit)
	{
		if (hasHit)
			return;
		KenHealth kenHealth = hit.collider.gameObject.GetComponentInParent<KenHealth>();
		if (kenHealth != null)
		{
			kenHealth.Damage(damage, true);
			hasHit = true;
		}
	}
}
