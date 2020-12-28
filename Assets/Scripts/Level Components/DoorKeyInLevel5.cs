using UnityEngine;

public class DoorKeyInLevel5 : Collectable
{
    [SerializeField] private GameObject door;
    
	protected override void Collect()
	{
		Destroy(door);
	}
}
