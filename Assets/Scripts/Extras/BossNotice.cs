using System;
using UnityEngine;

public class BossNotice : MonoBehaviour
{
  public static Action<EventType> OnEventFired;

  public enum EventType
  {
    BossFight
  }

  [SerializeField] private EventType eventType;
  [SerializeField] private LayerMask eventLayer;

  private bool eventFired;

  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("trigger enter");
    if (MyLibrary.CheckLayer(other.gameObject.layer, eventLayer))
    {
      Debug.Log("triggered");
      if (!eventFired)
      {
        OnEventFired?.Invoke(eventType);
        eventFired = true;
      }
    }
  }

}
