using UnityEngine;

public class Destroyable : MonoBehaviour
{
	//[SerializeField] private float lifeTimer = 1;

	public void DestroySelf()
	{
		Destroy(gameObject);
	}
}
