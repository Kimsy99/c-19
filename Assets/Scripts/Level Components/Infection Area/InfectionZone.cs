using UnityEngine;

public class InfectionZone : MonoBehaviour
{
    private Ken ken;
    private bool isInfectingKen=false;
    private readonly float infectionRate = 0.5F;
    // Start is called before the first frame update
    void Start()
    {
        ken = FindObjectOfType<Ken>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInfectingKen == true)
            ken.health.Infect(infectionRate * Time.deltaTime);
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