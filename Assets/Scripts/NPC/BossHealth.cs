public class BossHealth : NPCHealth
{
	protected override void Update()
	{
		if (!LevelManager.Instance.isBossReady)
			return;
		base.Update();
	}

	public override bool Damage(float damage, bool shouldFlash = false, float invulnerabilityTime = 0)
	{
		if (!LevelManager.Instance.isBossReady)
			return false;
		return base.Damage(damage, shouldFlash, invulnerabilityTime);
	}

	protected override void Die()
	{
		animator.SetBool(isDeadParameter, true);
	}
}
