using System.Collections;
using UnityEngine;

/// <summary>
/// GameObjects can apply this script for a flash effect. You can configure it to flash to
/// any color you want.
/// </summary>
public class Flashable : MonoBehaviour
{
	[SerializeField] private Color flashColor = Color.red;
	[SerializeField] private ParticleSystem blood = null;
	[SerializeField] private AudioEnum flashAudio = AudioEnum.NoAudio;

	[HideInInspector] public SpriteRenderer spriteRenderer = null;
	protected Coroutine revertCoroutine;

	// Use this for initialization
	protected virtual void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	/// <summary>
	/// Call this function to flash red.
	/// </summary>
	public void Flash()
	{
		Modify();
		if (blood != null)
			blood.Play();
		AudioManager.Instance.Play(flashAudio);
		if (revertCoroutine != null)
			StopCoroutine(revertCoroutine);
		revertCoroutine = StartCoroutine(Revert());
	}

	protected virtual void Modify()
	{
		spriteRenderer.color = flashColor;
	}

	protected virtual IEnumerator Revert()
	{
		yield return new WaitForSeconds(0.1F);
		spriteRenderer.color = Color.white;
		revertCoroutine = null;
	}
}