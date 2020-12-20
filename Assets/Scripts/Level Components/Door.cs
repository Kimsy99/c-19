using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
  private Animator animator;
  private BoxCollider2D boxCollider2D;
  [SerializeField] private DoorCollider boxColliderOpenDoor;
  private readonly int doorOpenParameter = Animator.StringToHash("HaveKey");
  public bool haveKey = false;
  private void Start()
  {
    animator = GetComponent<Animator>();
    boxCollider2D = GetComponent<BoxCollider2D>();
  }
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.C) && haveKey && boxColliderOpenDoor.openDoor == true)
    {
      OpenDoor();
    }
  }

  private void OpenDoor()
  {
    animator.SetTrigger(doorOpenParameter);
    boxCollider2D.isTrigger = true;
    boxColliderOpenDoor.doorPopUpPanel.SetActive(false);
  }

  //   private GameObject SelectReward()
  //   {
  //     int randomRewardIndex = Random.Range(0, rewards.Length);
  //     for (int i = 0; i < rewards.Length; i++)
  //     {
  //       return rewards[randomRewardIndex];
  //     }

  //     return null;
  //   }

  //   private void OnTriggerEnter2D(Collider2D other)
  //   {
  //     if (other.CompareTag("Player"))
  //     {
  //       canReward = true;
  //     }
  //   }

  //   private void OnTriggerExit2D(Collider2D other)
  //   {
  //     if (other.CompareTag("Player"))
  //     {
  //       canReward = false;
  //     }
  //   }

}
