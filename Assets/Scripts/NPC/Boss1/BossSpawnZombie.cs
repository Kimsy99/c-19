using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnZombie : MonoBehaviour
{
    [SerializeField] private GameObject[] zombies;
     [SerializeField] private NPCHealth bossHealth;
	// Use this for initialization
	void Start()
	{
		StartCoroutine(Spawn());
	}

	private IEnumerator Spawn()
	{
        if(bossHealth.Hp != 0){
            yield return new WaitForSeconds(Random.Range(1F,3F));
            Debug.Log("spawn");
            Instantiate(zombies[Random.Range(0, zombies.Length)], transform.position, Quaternion.identity);
            maxSpawn--;
        }

		StartCoroutine(Spawn());
	}
}
