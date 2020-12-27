using UnityEngine;

public class HealingZone : MonoBehaviour
{
	private Ken ken;
	private bool isInfectingKen=false;
	private float healingRate = -0.5F;
	// Start is called before the first frame update
	void Awake()
	{
		ken = FindObjectOfType<Ken>();
	}

	// Update is called once per frame
	void Update()
	{
		if(isInfectingKen == true)
			ken.health.Infect(healingRate * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			isInfectingKen = true;
			//Debug.Log("infecting");
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
			isInfectingKen = false;
	}
}