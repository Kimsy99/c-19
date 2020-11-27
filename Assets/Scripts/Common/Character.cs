using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField] private CharacterType characterType;

	public enum CharacterType
	{
		Player,
		NPC
	}
	

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
