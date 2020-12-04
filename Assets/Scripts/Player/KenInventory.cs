using UnityEngine;

public class KenInventory : MonoBehaviour
{
	GameObject[] inventory = new GameObject[5];
	
	private GameObject inventoryBox1;
	private GameObject inventoryBox2;
	private GameObject inventoryBox3;
	private GameObject inventoryBox4;
	private GameObject inventoryBox5;
	private GameObject selectedInventoryBox;
	private AudioSource switchInventory;

	// Start is called before the first frame update
	void Start()
	{
		inventoryBox1 = GameObject.Find("InventoryBox1");
		inventoryBox2 = GameObject.Find("InventoryBox2");
		inventoryBox3 = GameObject.Find("InventoryBox3");
		inventoryBox4 = GameObject.Find("InventoryBox4");
		inventoryBox5 = GameObject.Find("InventoryBox5");
		selectedInventoryBox = GameObject.Find("InventoryBoxSelected");
		switchInventory = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		//if (Input.GetKeyDown(KeyCode.Alpha1))

	}
}
