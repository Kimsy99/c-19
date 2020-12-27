using UnityEngine;
using Random = UnityEngine.Random;

public class Chest : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private Sprite chestOpenSprite = null;
	[SerializeField] private ChestLoot[] chestLoot = null;
	private Transform lootGeneratePosition;

	private SpriteRenderer spriteRenderer;
	private Ken ken;

	private bool chestOpened;

	void Awake()
	{
		lootGeneratePosition = transform.Find("LootGeneratePosition");

		spriteRenderer = GetComponent<SpriteRenderer>();
		ken = FindObjectOfType<Ken>();
	}

	private void Update()
	{
		if (!chestOpened && Input.GetKeyDown(KeyCode.Space))
		{
			if (Vector2.Distance(transform.position, ken.center.position) < 1.2F && CanOpen())
			{
				spriteRenderer.sprite = chestOpenSprite;
				GenerateLoot();
				AudioManager.Instance.Play(AudioEnum.ChestOpen);
			}
		}
	}

	private bool CanOpen()
	{
		Vector2 directionVector = transform.position - ken.center.position;
		float distance = Vector2.Distance(ken.center.position, transform.position);
		RaycastHit2D hit = Physics2D.Raycast(ken.center.position, directionVector, distance, LayerMask.GetMask("Wall"));
		return hit && hit.collider.gameObject.GetComponent<Chest>() != null;
	}

	private void GenerateLoot()
	{
		Instantiate(SelectLoot(), lootGeneratePosition.position, Quaternion.identity);
		chestOpened = true;
	}

	private Collectable SelectLoot()
	{
		int totalWeightage = 0;
		foreach (ChestLoot loot in chestLoot)
			totalWeightage += loot.weightage;

		int random = Random.Range(0, totalWeightage);
		int currentWeightage = 0;
		for (int i = 0; i < chestLoot.Length; i++)
		{
			currentWeightage += chestLoot[i].weightage;
			if (currentWeightage > random)
				return chestLoot[i].collectable;
		}
		return null;
	}
}
