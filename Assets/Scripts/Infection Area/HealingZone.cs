using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    private Ken ken;
    private bool isInfectingKen=false;
    private float healingRate = -0.03f;
    // Start is called before the first frame update
    void Start()
    {
        ken = GameObject.Find("Ken").GetComponent<Ken>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInfectingKen == true){
            ken.health.Infect(healingRate);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			isInfectingKen = true;
			ken.health.Infect(healingRate);
            Debug.Log("infecting");
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
			isInfectingKen = false;
	}
}