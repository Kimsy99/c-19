using UnityEngine;

public class KenInventory : MonoBehaviour
{
	GameObject[] inventory = new GameObject[5];
	
	private Vector3 inventoryBox1Pos;
	private Vector3 inventoryBox2Pos;
	private Vector3 inventoryBox3Pos;
	private Vector3 inventoryBox4Pos;
	private Vector3 inventoryBox5Pos;
	private GameObject selectedInventoryBox;

	private int selectedInventoryIndex;

	// Start is called before the first frame update
	void Start()
	{
		inventoryBox1Pos = GameObject.Find("InventoryBox1").transform.position;
		inventoryBox2Pos = GameObject.Find("InventoryBox2").transform.position;
		inventoryBox3Pos = GameObject.Find("InventoryBox3").transform.position;
		inventoryBox4Pos = GameObject.Find("InventoryBox4").transform.position;
		inventoryBox5Pos = GameObject.Find("InventoryBox5").transform.position;
		selectedInventoryBox = GameObject.Find("InventoryBoxSelected");
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedInventoryBox.transform.position = inventoryBox1Pos;
			selectedInventoryIndex = 0;
			SoundManager.Instance.Play(SoundManager.Sound.KenSelect);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			selectedInventoryBox.transform.position = inventoryBox2Pos;
			selectedInventoryIndex = 1;
			SoundManager.Instance.Play(SoundManager.Sound.KenSelect);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			selectedInventoryBox.transform.position = inventoryBox3Pos;
			selectedInventoryIndex = 2;
			SoundManager.Instance.Play(SoundManager.Sound.KenSelect);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			selectedInventoryBox.transform.position = inventoryBox4Pos;
			selectedInventoryIndex = 3;
			SoundManager.Instance.Play(SoundManager.Sound.KenSelect);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			selectedInventoryBox.transform.position = inventoryBox5Pos;
			selectedInventoryIndex = 4;
			SoundManager.Instance.Play(SoundManager.Sound.KenSelect);
		}
	}
}
