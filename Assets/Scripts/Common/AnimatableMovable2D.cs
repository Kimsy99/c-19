using UnityEngine;

/// <summary>
/// AnimatableMovable2Ds are an extension to Movable2Ds in that they contain animations and have an Animator component.
/// </summary>
public class AnimatableMovable2D : Movable2D
{
	protected Animator animator;
	protected readonly int isMovingParamater = Animator.StringToHash("IsMoving");

	protected override void Awake()
	{
		base.Awake();
		animator = GetComponent<Animator>();
	}

	protected virtual void Update()
	{
		animator.SetBool(isMovingParamater, Speed > 0);
	}
}
