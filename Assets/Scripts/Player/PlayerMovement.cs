using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float moveSpeed = 5f;
  public Rigidbody2D rb;
  public Camera cam;
  Vector2 movement;
  Vector2 mousePos;
  void FixedUpdate()
  {
    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    Vector2 lookDirection = mousePos - rb.position; //subtract vector from target to current position, we will get vector from currpos to target
    float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f; // return angle between xaxis and 2d vector starting at 0 and terminate at X,Y slope
    rb.rotation = angle;
  }

  // Update is called once per frame
  void Update()
  {
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
    mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
  }
}
