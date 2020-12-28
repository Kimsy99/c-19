using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	private Weapon weapon;

	private Image image;
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
		image = transform.Find("InventorySprite").GetComponent<Image>();
		image.enabled = false;
		itemCounter = transform.Find("ItemCounter").GetComponent<TextMeshProUGUI>();
	}

	/// <summary>
	/// Updates the slot with the sprite that this inventory slot is holding, as well as its item count.
	/// </summary>
	public void UpdateSlot()
	{
		if (weapon != null)
		{
			image.enabled = true;
			image.sprite = weapon.weaponSettings.displaySprite;
			image.SetNativeSize();
		}
		else
			image.enabled = false;
		itemCounter.text = weapon == null || weapon.weaponSettings.maxBulletCount == -1 ? "" : weapon.bulletCount.ToString();
	}
}
