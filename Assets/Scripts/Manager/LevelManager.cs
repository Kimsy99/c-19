using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private Character playableCharacter;
	[SerializeField] private Transform spawnPosition;

	public Item firstItem;

	void Start()
	{
		Item dummyItem = Instantiate<Item>(firstItem, transform);
		InventoryManager.Instance.AddItem(dummyItem);
	}
}
