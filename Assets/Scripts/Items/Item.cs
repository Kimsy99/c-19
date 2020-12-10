using UnityEngine;

/// <summary>
/// Generic item class, all in game collectable items (weapons, medkits etc.) extend this.
/// </summary>
public abstract class Item : MonoBehaviour
{
	/** Number of items in stack, can also be used for bullet count */
	private int count;
	/** Maximum number of items allowed in the stack */
	[SerializeField] private int maxCount = 1;

	/** Sprite for this item, used for displaying it in hand, inventory, and on the ground. */
	[SerializeField] private Sprite itemSprite;
	/** Inventory slot for this item. If this item is not in inventory, this will be null. */
	public InventorySlot inventorySlot;

	public int Count
	{
		get => count;
		set
		{
			count = value;
			if (inventorySlot != null)
				inventorySlot.UpdateSlot();
		}
	}

	public int MaxCount => maxCount;
	public Sprite ItemSprite => itemSprite;

	protected virtual void Awake()
	{
		Count = MaxCount;
	}

	/// <summary>
	/// Called when this item is used (when left clicking).
	/// </summary>
	public abstract void Use();	
}
