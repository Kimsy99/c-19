using UnityEngine;

public class Pill : Collectable
{
	[SerializeField] private int infectionToReduce = 1;

	protected override void Collect()
	{
		ken.health.Infection -= infectionToReduce;
		AudioManager.Instance.Play(AudioEnum.Collect);
	}
}
