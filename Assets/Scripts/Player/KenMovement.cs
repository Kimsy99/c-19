using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class KenMovement : MonoBehaviour
{
    public float moveSpeed = 5F;

    private Rigidbody2D body;
    private Vector2 movementVec = new Vector2();

	private void Start()
	{
        body = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
    {
        body.MovePosition(body.position + movementVec * moveSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        movementVec.x = Input.GetAxisRaw("Horizontal");
        movementVec.y = Input.GetAxisRaw("Vertical");
    }
}
