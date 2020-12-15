using UnityEngine;

public class Ken : MonoBehaviour
{
	[HideInInspector] public SpriteFlippable2D spriteFlippable2D;
	[HideInInspector] public Flashable flashable;
	[HideInInspector] public KenHealth health;
	[HideInInspector] public KenMovement movement;
	[HideInInspector] public KenShooting shooting;

	void Awake()
	{
		spriteFlippable2D = GetComponent<SpriteFlippable2D>();
		flashable = GetComponent<Flashable>();
		health = GetComponent<KenHealth>();
		movement = GetComponent<KenMovement>();
		shooting = GetComponent<KenShooting>();
	}
}
