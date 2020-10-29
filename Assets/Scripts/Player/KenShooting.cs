using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenShooting : MonoBehaviour
{
  public Transform ShootingPoint;
  public GameObject bulletPrefab;
  public float bulletForce = 20F;

  public Camera cam;
  private Rigidbody2D body;
  private Vector2 mousePos = new Vector2();

  private void Start()
  {
    body = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    if (Input.GetButtonDown("Fire1"))
      Shoot();
  }

  private void Shoot()
  {
    // Obtain quaternion from body to mouse
    Vector2 lookDirection = mousePos - body.position; //subtract vector from target to current position, we will get vector from currpos to target
    float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg; // return angle between xaxis and 2d vector starting at 0 and terminate at X,Y slope
    Quaternion lookQuaternion = Quaternion.Euler(0, 0, angle);

    GameObject bullet = Instantiate(bulletPrefab, ShootingPoint.position, lookQuaternion);
    //bullet.transform.localRotation = lookQuaternion;
    Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();

    //bulletBody.LookAt(mousePos);
    bulletBody.AddForce(transform.TransformDirection(lookDirection).normalized * bulletForce, ForceMode2D.Impulse);
  }
}
