using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
  public bool openDoor = false;
  [SerializeField] public GameObject doorPopUpPanel;
  void Start()
  {
    doorPopUpPanel.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {

  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      openDoor = true;
      doorPopUpPanel.SetActive(true);
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      doorPopUpPanel.SetActive(false);
    }
  }

}
