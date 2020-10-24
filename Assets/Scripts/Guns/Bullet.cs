using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject hitEffect;
	public GameObject bullet;

	void OnCollisionEnter2D(Collision2D collision)
	{

	}
	
	void OnBecameInvisible()
	{
		print("Destroy");
		Destroy(bullet);
	}
}
