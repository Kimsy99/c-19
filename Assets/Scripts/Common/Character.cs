using UnityEngine;

public class Character : MonoBehaviour
{
  [SerializeField] public CharacterType characterType;

  public enum CharacterType
  {
    Player,
    NPC
  }
}
