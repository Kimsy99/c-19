using TMPro;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
	private Weapon weapon;

	private SpriteRenderer spriteRenderer;
	private TextMeshProUGUI itemCounter;

	public Weapon Weapon
	{
		get => weapon;
		set
		{
			weapon = value;
			UpdateSlot();
		}
	}

	void Awake()
	{
		spriteRenderer = transform.Find("InventorySprite").GetComponent<SpriteRenderer>();
		itemCounter = transform.Find("ItemCounter").GetComponent<TextMeshProUGUI>();
	}

	/// <summary>
	/// Updates the slot with the sprite that this inventory slot is holding, as well as its item count.
	/// </summary>
	public void UpdateSlot()
	{
		spriteRenderer.sprite = weapon?.weaponSettings.displaySprite;
		itemCounter.text = weapon == null || weapon.weaponSettings.maxBulletCount == -1 ? "" : weapon.bulletCount.ToString();
	}
}
