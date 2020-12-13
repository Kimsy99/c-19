﻿using System.Collections;
using UnityEngine;

/// <summary>
/// GameObjects can apply this script for a damage flash red effect.
/// </summary>
public class Flashable : MonoBehaviour
{
	[HideInInspector] public SpriteRenderer spriteRenderer;
	private Coroutine revertCoroutine;

	// Use this for initialization
	protected virtual void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	/// <summary>
	/// Call this function to flash red.
	/// </summary>
	public virtual void Flash()
	{
		spriteRenderer.color = Color.red;
		if (revertCoroutine != null)
			StopCoroutine(revertCoroutine);
		revertCoroutine = StartCoroutine(Revert());
	}

	private IEnumerator Revert()
	{
		yield return new WaitForSeconds(0.1F);
		spriteRenderer.color = Color.white;
		revertCoroutine = null;
	}
}