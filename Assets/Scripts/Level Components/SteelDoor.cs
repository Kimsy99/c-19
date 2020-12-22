
using UnityEngine;

public class SteelDoor : MonoBehaviour
{
	private Animator animator;
	private readonly int isOpenParameter = Animator.StringToHash("IsOpen");
	private int objectCount = 0;

	void Awake()
	{
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		float t = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		if (!animator.GetBool(isOpenParameter) && objectCount > 0)
		{
			animator.SetBool(isOpenParameter, true);
			animator.Play("SteelDoorOpening", 0, Mathf.Max(1 - t, 0));
		}
		else if (animator.GetBool(isOpenParameter) && objectCount == 0)
		{
			animator.SetBool(isOpenParameter, false);
			animator.Play("SteelDoorClosing", 0, Mathf.Max(1 - t, 0));
		}
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer != LayerMask.NameToLayer("PlayerBullet"))
			objectCount++;
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.layer != LayerMask.NameToLayer("PlayerBullet"))
			objectCount--;
	}
}
