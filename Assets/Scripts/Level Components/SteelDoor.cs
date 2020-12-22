using UnityEngine;

public class SteelDoor : MonoBehaviour
{
	private Animator animator;
	private readonly int isOpenParameter = Animator.StringToHash("IsOpen");
	private int objectCount = 0;
	[SerializeField] private bool isVertical = false;
	[SerializeField] private bool isManual = false;
	public bool isOpen;

	void Awake()
	{
		animator = GetComponent<Animator>();
		animator.Play(isVertical ? "SteelDoorVerticalClosing" : "SteelDoorClosing", 0, 1);
	}

	void Update()
	{
		float t = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		if (!animator.GetBool(isOpenParameter) && (!isManual && objectCount > 0 || isManual && isOpen))
		{
			animator.SetBool(isOpenParameter, true);
			animator.Play(isVertical ? "SteelDoorVerticalOpening" : "SteelDoorOpening", 0, Mathf.Max(1 - t, 0));
		}
		else if (animator.GetBool(isOpenParameter) && (!isManual && objectCount == 0 || isManual && !isOpen))
		{
			animator.SetBool(isOpenParameter, false);
			animator.Play(isVertical ? "SteelDoorVerticalClosing" : "SteelDoorClosing", 0, Mathf.Max(1 - t, 0));
		}
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer != LayerMask.NameToLayer("PlayerBullet") && collision.gameObject.layer != LayerMask.NameToLayer("ShotBlocker"))
			objectCount++;
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.layer != LayerMask.NameToLayer("PlayerBullet") && collision.gameObject.layer != LayerMask.NameToLayer("ShotBlocker"))
			objectCount--;
	}
}
