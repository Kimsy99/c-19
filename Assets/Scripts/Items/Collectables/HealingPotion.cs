using UnityEngine;

public class HealingPotion : Collectable
{
	[SerializeField] private int healthToAdd = 1;

	protected override void Collect()
	{
		ken.health.Hp += healthToAdd;
	}
}
