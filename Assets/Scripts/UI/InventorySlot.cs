using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	private Item item;

	private SpriteRenderer spriteRenderer;
	private Text itemCounter;

	public Item Item
	{
		get => item;
		set
		{
			item = value;
			UpdateSlot();
		}
	}

	void Start()
	{
		spriteRenderer = transform.Find("InventorySprite").GetComponent<SpriteRenderer>();
		itemCounter = transform.Find("ItemCounter").GetComponent<Text>();
	}

	/// <summary>
	/// Updates the slot with the sprite that this inventory slot is holding, as well as its item count.
	/// </summary>
	public void UpdateSlot()
	{
		spriteRenderer.sprite = item.ItemSprite;
		itemCounter.text = item.Count.ToString();
	}
}
