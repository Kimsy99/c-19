using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField] private CharacterType characterType;

	public enum CharacterType
	{
		Player,
		NPC
	}
}
