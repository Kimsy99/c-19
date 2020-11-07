using UnityEngine;

public class AnimatableMovable2D : Movable2D
{
	private Animator animator;
	private readonly int movingParamater = Animator.StringToHash("Moving");

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (Speed > 0)
		{
			print("moving");
			//animator.SetBool(movingParamater, value: true);
		}
		else
		{
			print("not moving");
			//animator.SetBool(movingParamater, value: false);
		}
	}
}
