using UnityEngine;

public class Destroyer : MonoBehaviour
{
	//[SerializeField] private float lifeTimer = 1;

	private void DestroySelf()
	{
		Destroy(gameObject);
	}
}
