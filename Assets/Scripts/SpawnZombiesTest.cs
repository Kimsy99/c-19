using System.Collections;
using UnityEngine;

public class SpawnZombiesTest : MonoBehaviour
{
	public GameObject[] zombies;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(Spawn());
	}

	private IEnumerator Spawn()
	{
		yield return new WaitForSeconds(Random.Range(1F, 3F));
		Instantiate(zombies[Random.Range(0, zombies.Length)], transform.position, Quaternion.identity);
		StartCoroutine(Spawn());
	}
}
