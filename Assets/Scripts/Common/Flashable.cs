using System.Collections;
using UnityEngine;

public class Flashable : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	protected virtual void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	public void flash()
	{
		spriteRenderer.color = Color.red;
		StartCoroutine(FlashWhite());
	}

	private IEnumerator FlashWhite()
	{
		yield return new WaitForSeconds(0.1F);
		spriteRenderer.color = Color.white;
	}
}