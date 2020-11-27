using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    // Controls the current movement of this character    
public Vector2 CurrentMovement { get; set; }


	
    // Internal
    private Rigidbody2D myRigidbody2D;
	
    // Start is called before the first frame update
    void Start()
{
      
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
	
    
}











