using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardOrientable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void FixedUpdate()
	{
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        Vector3 localVel = transform.InverseTransformDirection(body.velocity);
        transform.localRotation = Quaternion.LookRotation(localVel);
    }

	// Update is called once per frame
	void Update()
    {
        
    }
}
