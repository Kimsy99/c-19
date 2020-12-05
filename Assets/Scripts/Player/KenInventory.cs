using UnityEngine;

public class KenInventory : MonoBehaviour
{
	GameObject[] inventory = new GameObject[5];
	
	private Transform slot0Pos;
	private Transform slot1Pos;
	private Transform slot2Pos;
	private Transform slot3Pos;
	private Transform slot4Pos;
	private GameObject activeSlot;

	private int activeSlotIndex;

	// Start is called before the first frame update
	void Start()
	{
		slot0Pos = GameObject.Find("InventorySlot0").transform;
		slot1Pos = GameObject.Find("InventorySlot1").transform;
		slot2Pos = GameObject.Find("InventorySlot2").transform;
		slot3Pos = GameObject.Find("InventorySlot3").transform;
		slot4Pos = GameObject.Find("InventorySlot4").transform;
		activeSlot = GameObject.Find("ActiveInventorySlot");
	}

	// Update is called once per frame
	void Update()
	{
		// Switch inventory slot with number keys
		if (Input.GetKeyDown(KeyCode.Alpha1))
			SetActiveInventory(0);
		else if (Input.GetKeyDown(KeyCode.Alpha2))
			SetActiveInventory(1);
		else if (Input.GetKeyDown(KeyCode.Alpha3))
			SetActiveInventory(2);
		else if (Input.GetKeyDown(KeyCode.Alpha4))
			SetActiveInventory(3);
		else if (Input.GetKeyDown(KeyCode.Alpha5))
			SetActiveInventory(4);

		// Switch inventory slot with scroll wheel
		if (Input.mouseScrollDelta.y < 0)
			SetActiveInventory((activeSlotIndex + 1) % 5);
		else if (Input.mouseScrollDelta.y > 0)
			SetActiveInventory((activeSlotIndex + 4) % 5);
	}

	private void SetActiveInventory(int index)
	{
		activeSlotIndex = index;
		switch (index)
		{
			case 0:
				activeSlot.transform.position = slot0Pos.position;
				break;
			case 1:
				activeSlot.transform.position = slot1Pos.position;
				break;
			case 2:
				activeSlot.transform.position = slot2Pos.position;
				break;
			case 3:
				activeSlot.transform.position = slot3Pos.position;
				break;
			case 4:
				activeSlot.transform.position = slot4Pos.position;
				break;
		}
		SoundManager.Instance.Play(SoundManager.Sound.KenSelect);
	}
}
