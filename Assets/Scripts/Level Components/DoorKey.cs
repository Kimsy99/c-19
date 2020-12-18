using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : Collectable
{
    private Door door;
    void Start(){
        door = GameObject.Find("topdown-door").GetComponent<Door>();
    }
	protected override void Collect()
	{
		door.haveKey = true;
	}
}
