using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1 : NPCMovement
{
    [SerializeField] private float attackRange;
    private Transform target;

    private readonly int isAttack = Animator.StringToHash("isAttack");
    [SerializeField] private GameObject projectile; //projectile Object
                                                    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        //player outside the range
        if (Vector2.Distance(transform.position, target.position) >= attackRange)
        {
            Debug.Log("No player");
            animator.SetBool(isAttack, value: false);
            // Patrol(attackRange);
        }
        else
        {
            animator.SetBool(isAttack, value: true);
            // Shot();
            Debug.Log("Found player");

        }
        Patrol(attackRange);
        //test minus life point
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponentInChildren<NPCHealthBar>().hp -= 25;
        }
    }
    protected void Patrol(float attackRange)
    {
        //movement
        Vector2 nextPosition = Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime);
        // wayPointTarget = wayPoint01;
        // transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) <= attackRange)
        {
            wayPointTarget = target;
        }
        else
        {
            if (wayPointTarget == target)
            {
                wayPointTarget = wayPoint02;
            }
            if (Vector2.Distance(transform.position, wayPoint01.position) <= 0.1f)
            {
                wayPointTarget = wayPoint02;
            }
            if (Vector2.Distance(transform.position, wayPoint02.position) <= 0.1f)
            {
                wayPointTarget = wayPoint01;
            }
        }
        // transform.direction
        //controller
        Vector2 direction = nextPosition - (Vector2)transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);

        // Debug.Log(Vector2.MoveTowards(transform.position, wayPointTarget.position, walkSpeed * Time.deltaTime));


        // vx = Input.GetAxisRaw("Horizontal");
        // vy = Input.GetAxisRaw("Vertical");
        // Debug.Log(-(transform.position.x - nextPosition.x) * 10 + " " + -(transform.position.y - nextPosition.y) * 10);
        Direction = angle;
        Speed = walkSpeed;
        // SetVelocity(vx * walkSpeed, vy * walkSpeed);

        // SetVelocity(vx * walkSpeed, vy * walkSpeed);
        // SetVelocity(-(transform.position.x - nextPosition.x) * 7 * walkSpeed, (-(transform.position.y - nextPosition.y) * 7) * walkSpeed);
        // UpdateAnimations();

    }
    public void Shot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
