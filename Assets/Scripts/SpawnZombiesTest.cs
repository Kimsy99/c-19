using System.Collections;
using UnityEngine;

public class SpawnZombiesTest : MonoBehaviour
{
  public GameObject[] zombies;
  private int maxSpawn = 10;

  // Use this for initialization
  void Start()
  {
    StartCoroutine(Spawn());
  }

  private IEnumerator Spawn()
  {
    yield return new WaitForSeconds(Random.Range(1F, 3F));
    if (maxSpawn > 0)
    {
      Debug.Log("spawn");
      Instantiate(zombies[Random.Range(0, zombies.Length)], transform.position, Quaternion.identity);
      maxSpawn--;
    }
    StartCoroutine(Spawn());
  }
}
