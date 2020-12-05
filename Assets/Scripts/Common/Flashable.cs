using System.Collections;
using UnityEngine;

/// <summary>
/// GameObjects can apply this script for a damage flash red effect.
/// </summary>
public class Flashable : MonoBehaviour
{
	[HideInInspector] public SpriteRenderer spriteRenderer;

	// Use this for initialization
	protected virtual void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	/// <summary>
	/// Call this function to flash red.
	/// </summary>
	public virtual void Flash()
	{
		spriteRenderer.color = Color.red;
		StartCoroutine(Revert());
	}

	private IEnumerator Revert()
	{
		yield return new WaitForSeconds(0.1F);
		spriteRenderer.color = Color.white;
	}
}