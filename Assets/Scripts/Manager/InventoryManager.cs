using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reponsible for the storing of actual items and updating the inventory UI. Can handle item adding and removal.
/// </summary>
public class InventoryManager : Singleton<InventoryManager>
{
	/** Items in inventory. */
	[SerializeField] private Item[] items = new Item[5];
	private readonly Dictionary<int, InventorySlot> slotDictionary = new Dictionary<int, InventorySlot>();

	private RectTransform slot0, slot1, slot2, slot3, slot4;
	private RectTransform activeSlot;

	// Start is called before the first frame update
	protected override void Awake()
	{
		slot0 = (RectTransform)GameObject.Find("InventorySlot0").transform;
		slot1 = (RectTransform)GameObject.Find("InventorySlot1").transform;
		slot2 = (RectTransform)GameObject.Find("InventorySlot2").transform;
		slot3 = (RectTransform)GameObject.Find("InventorySlot3").transform;
		slot4 = (RectTransform)GameObject.Find("InventorySlot4").transform;
		activeSlot = (RectTransform)GameObject.Find("ActiveInventorySlot").transform;

		slotDictionary.Add(0, slot0.GetComponent<InventorySlot>());
		slotDictionary.Add(1, slot1.GetComponent<InventorySlot>());
		slotDictionary.Add(2, slot2.GetComponent<InventorySlot>());
		slotDictionary.Add(3, slot3.GetComponent<InventorySlot>());
		slotDictionary.Add(4, slot4.GetComponent<InventorySlot>());
	}

	public void SetActiveSlot(int index)
	{
		activeSlot.anchoredPosition = ((RectTransform)slotDictionary[index].gameObject.transform).anchoredPosition;
		SoundManager.Instance.Play(SoundManager.Sound.KenSelect);
	}

	/// <summary>
	/// Tries to add a new item to the inventory. If does this by searching through the inventory for an empty
	/// slot. If an empty slot is found, then the item is added.
	/// </summary>
	/// <param name="item">the item to add</param>
	/// <returns>True if the item is successfully added, false if the inventory is full.</returns>
	public bool AddItem(Item item)
	{
		// Find an empty slot
		for (int  i = 0; i < 5; i++)
		{
			if (items[i] == null)
			{
				items[i] = item; // Add the item
				item.inventorySlot = slotDictionary[i];
				item.inventorySlot.Item = item; // Update inventory references
				return true;
			}
		}
		return false;
	}

	public Item GetItem(int index)
	{
		return items[index];
	}

	/// <summary>
	/// Removes a specific item from the inventory.
	/// </summary>
	/// <param name="index">index of the item</param>
	/// <returns>True</returns>
	public bool RemoveItem(int index)
	{
		items[index].inventorySlot = null;
		items[index] = null;
		return true;
	}
}
