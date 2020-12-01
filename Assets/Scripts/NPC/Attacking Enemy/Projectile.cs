﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  private Transform target;
  [SerializeField] private float moveSpeed;

  public GameObject destroyEffect; //after 2 sec and never touch player, trigger
  public GameObject attackEffect; //if rouch the player, will trigger this effect

  private float lifeTimer;
  [SerializeField] private float maxLife = 2.0f;

  private void Start()
  {
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
  }

  private void Update()
  {
    transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

    lifeTimer += Time.deltaTime;
    if (lifeTimer >= maxLife)
    {
      Instantiate(destroyEffect, transform.position, Quaternion.identity);
      Destroy(gameObject);
    }
  }

  //projectile collide with player
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      //   other.GetComponentInChildren<HealthBar>().hp -= 35;
      Instantiate(attackEffect, transform.position, Quaternion.identity);
      Destroy(gameObject);
    }
  }

}
