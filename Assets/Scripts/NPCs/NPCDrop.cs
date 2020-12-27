using UnityEngine;

public class NPCDrop : MonoBehaviour
{
	private NPC npc;
	[SerializeField] private GameObject objectToDrop = null;
	[Range(0, 1)]
	[SerializeField] private float probability = 1;

	// Start is called before the first frame update
	void Awake()
	{
		npc = GetComponent<NPC>();
	}

	void Start()
	{
		npc.health.OnDie += DropLoot;
	}

	// Update is called once per frame
	void DropLoot()
	{
		if (Random.Range(0F, 1F) <= probability)
			Instantiate(objectToDrop, transform.position, Quaternion.identity);
	}
}
