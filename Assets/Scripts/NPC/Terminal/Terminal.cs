using UnityEngine;

public class Terminal : MonoBehaviour
{
	[HideInInspector] public Animator animator;
	public readonly int nextPhaseTriggerParameter = Animator.StringToHash("NextPhase");

	void Awake()
	{
		animator = GetComponent<Animator>();
	}
}
