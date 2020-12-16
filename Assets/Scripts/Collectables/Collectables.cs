using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private bool canDestroyItem = true; //this item is able to be destroyed
	protected Ken ken;
	protected GameObject objectCollided;
	protected SpriteRenderer spriteRenderer;
	protected Collider2D collider2D;

	private void Start()
	{
		ken = GameObject.Find("Ken").GetComponent<Ken>();
		spriteRenderer = GetComponent<SpriteRenderer>(); //bcs when we collider we need it -> the item will be destroyed as we obtained it
		collider2D = GetComponent<Collider2D>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		objectCollided = other.gameObject;
		if (IsPickable())
		{
			Pick();
			PlayEffects();
			if (canDestroyItem)
			{
				Destroy(gameObject);
			}
			else
			{
				spriteRenderer.enabled = false;
				collider2D.enabled = false;
			}
		}
	}

	protected virtual bool IsPickable()
	{
		return true;
		//character = objectCollided.GetComponent<Character>(); //see can collide or not
		//if (character == null)
		//{
		//  return false;
		//}
		//return character.characterType == Character.CharacterType.Player; //only allow player to collect the item
	}
	protected virtual void Pick()
	{

	}
	protected virtual void PlayEffects()
	{

	}
}
