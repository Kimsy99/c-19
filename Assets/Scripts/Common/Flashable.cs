using System.Collections;
using UnityEngine;

/// <summary>
/// For all GameObjects that can flash red.
/// </summary>
public class Flashable : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	protected virtual void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
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