using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door")]
    [SerializeField] private bool autoDoor = true;

    [Header("For door require key")]
    [SerializeField] private string keyName;
    [SerializeField] private GameObject openDoorHint;

    [Header("Sound Effect")]
    [SerializeField] private AudioEnum scanCard;
    [SerializeField] private AudioEnum openDoor;
    
    private Animator animator;
    private readonly int doorOpenParameter = Animator.StringToHash("DoorOpen");
    private readonly int doorCloseParameter = Animator.StringToHash("DoorClose");

    protected bool unlocked = false;
    private bool doorOpened = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // only for door require key
        if (!doorOpened && unlocked)
        {
            openDoorHint.SetActive(false);
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        doorOpened = true;
        
        animator.SetTrigger(doorOpenParameter);
        AudioManager.Instance.Play(openDoor);
    }

    private void CloseDoor()
    {
        doorOpened = false;

        animator.SetTrigger(doorCloseParameter);
        AudioManager.Instance.Play(openDoor);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (autoDoor)
                OpenDoor();
            else
            {
                if (!doorOpened)
                    openDoorHint.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        LockDoor();
        if (other.CompareTag("Player"))
        {
            if (autoDoor)
                CloseDoor();
            else
                openDoorHint.SetActive(false);
        }
    }

    private void UnlockDoor()
    {
        unlocked = true;
        AudioManager.Instance.Play(scanCard);
    }

    private void LockDoor()
    {
        unlocked = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!autoDoor && !doorOpened)
        {
            if (other.CompareTag("Player"))
            {
                WeaponSettings weaponSetting = other.gameObject.GetComponentInParent<Ken>().GetComponentInChildren<HeldWeapon>().WeaponSettings;
                if (weaponSetting != null)
                {
                    if (weaponSetting.displayName.Equals(keyName))
                        UnlockDoor();
                }
            }
        }
    }
}
