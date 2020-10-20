using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
  public Transform ShootingPoint;
  public GameObject bulletPrefab;
  public float bulletForce = 20f;

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Fire1"))
    {
      Shoot();
    }
  }
  void Shoot()
  {
    GameObject bullet = Instantiate(bulletPrefab, ShootingPoint.position, ShootingPoint.rotation);
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    rb.AddForce(ShootingPoint.up * bulletForce, ForceMode2D.Impulse);
  }
}
