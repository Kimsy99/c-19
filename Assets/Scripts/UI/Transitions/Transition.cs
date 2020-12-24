using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Transition : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}


	/// 播放转场前的动画
	public void StartTrans()
	{
		animator.SetTrigger("Start");
	}

	/// <summary>
	/// 播放转场后的动画
	/// </summary>
	public void EndTrans()
	{
		animator.SetTrigger("End");
	}

	/// 当前动画是否播放完成
	public bool IsAnimationDone()
	{
		return animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1;
	}
}
