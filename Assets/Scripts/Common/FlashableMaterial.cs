using System.Collections;
using UnityEngine;

/// <summary>
/// Variant of Flashable that flashes to a custom material.
/// </summary>
public class FlashableMaterial : Flashable
{
	[SerializeField] private Material flashMaterial = null;
	private Material prevMaterial;

	protected override void Awake()
	{
		base.Awake();
		prevMaterial = spriteRenderer.material;
	}

	protected override void Modify()
	{
		spriteRenderer.material = flashMaterial;
	}

	protected override void Revert()
	{
		spriteRenderer.material = prevMaterial;
	}
}