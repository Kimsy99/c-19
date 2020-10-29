using System.Collections;
using System.Collections.Generic;
using UnityEngine; //unity library

public class Character : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D; //created rigidbody class here then we link it in the start
  public enum CharacterTypes // 2 type of character AI or player
  {
    Player,
    AI
  }
  [SerializeField] private CharacterTypes characterType; //serialized field ensure this character type appears in inspector (only if private) // or we can use public (but this can be used in other class file)

  // Start is called before the first frame update
  void Start()
  {
    //declare component
  }

  // Update is called once per frame
  void Update()
  {

  }
}
