using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyInLevel5 : Collectable
{
    //[SerializeField] private string doorName;
    [SerializeField] private Door door;
    
	protected override void Collect()
	{
		door.haveKey = true;
	}
}
