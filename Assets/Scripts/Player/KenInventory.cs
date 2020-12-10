using UnityEngine;

public class KenInventory : MonoBehaviour
{
	private int activeSlotIndex = 0;

	private KenHealth kenHealth;

	private int ActiveSlotIndex
	{
		get => activeSlotIndex;
		set
		{
			activeSlotIndex = value;
			InventoryManager.Instance.SetActiveSlot(activeSlotIndex);
		}
	}

	void Awake()
	{
		kenHealth = GetComponent<KenHealth>();
	}

	void Update()
	{
		// Switch inventory slot with number keys
		if (Input.GetKeyDown(KeyCode.Alpha1))
			ActiveSlotIndex = 0;
		else if (Input.GetKeyDown(KeyCode.Alpha2))
			ActiveSlotIndex = 1;
		else if (Input.GetKeyDown(KeyCode.Alpha3))
			ActiveSlotIndex = 2;
		else if (Input.GetKeyDown(KeyCode.Alpha4))
			ActiveSlotIndex = 3;
		else if (Input.GetKeyDown(KeyCode.Alpha5))
			ActiveSlotIndex = 4;

		// Switch inventory slot with scroll wheel
		if (Input.mouseScrollDelta.y < 0)
			ActiveSlotIndex = (ActiveSlotIndex + 1) % 5;
		else if (Input.mouseScrollDelta.y > 0)
			ActiveSlotIndex = (ActiveSlotIndex + 4) % 5;

		// Attempt to use item in active inventory slot
		if (Input.GetButtonDown("Fire1") && !kenHealth.IsDead())
		{
			Item activeItem = InventoryManager.Instance.GetItem(ActiveSlotIndex);
			if (activeItem != null)
				activeItem.Use();
			else
				print("No item to use");
		}
	}
}
