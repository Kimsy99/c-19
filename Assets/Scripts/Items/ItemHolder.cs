using UnityEngine;

public class ItemHolder : MonoBehaviour
{
	private KenMovement kenMovement;
	private Animator animator;
	private readonly int isMovingParameter = Animator.StringToHash("IsMoving");

	void Awake()
	{
		kenMovement = GetComponentInParent<KenMovement>();
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		animator.SetBool(isMovingParameter, kenMovement.Speed > 0);
	}
}
