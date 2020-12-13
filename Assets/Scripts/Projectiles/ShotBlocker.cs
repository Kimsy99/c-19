using UnityEngine;

public class ShotBlocker : Bullet
{
	protected override void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("NPC"))
        {
			Debug.Log("Shot block");
			other.gameObject.GetComponent<Flashable>().Flash();
			other.gameObject.GetComponentInChildren<NPCHealthBar>().hp -= damage;
        }
    }
}
