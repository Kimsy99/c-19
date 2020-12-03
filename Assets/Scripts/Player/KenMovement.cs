using UnityEngine;

public class KenMovement : Movable2D
{
    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float runSpeed = 15;
    
    // Update is called once per frame
    void Update()
    {
        float vx = Input.GetAxisRaw("Horizontal");
        float vy = Input.GetAxisRaw("Vertical");

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        SetVelocity(vx * speed, vy * speed);
    }
}
