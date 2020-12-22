public class BossHealth : NPCHealth
{
	protected override void Update()
	{
		if (!LevelManager.Instance.IsBossReady)
			return;
		base.Update();
	}

	public override bool Damage(float damage, bool shouldFlash = false, float invulnerabilityTime = 0)
	{
		if (!LevelManager.Instance.IsBossReady)
			return false;
		return base.Damage(damage, shouldFlash, invulnerabilityTime);
	}

	protected override void Die()
	{
		animator.SetBool(isDeadParameter, true);
	}
}
