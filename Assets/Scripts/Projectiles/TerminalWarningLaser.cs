using UnityEngine;

public class TerminalWarningLaser : Laser
{
	public float direction;

	void Start()
	{
		Destroy(gameObject, 0.1F);
	}

	protected override void Update()
	{
		base.Update();
		ShootLaser(LayerMask.GetMask("Wall"), direction);
	}
}
