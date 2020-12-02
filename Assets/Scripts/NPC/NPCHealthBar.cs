using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPCHealthBar : MonoBehaviour
{
  public Image hpImage;
  public Image hpEffectImage;
  public float hp;
  [SerializeField] private float maxHp;
  [SerializeField] private float hurtSpeed = 0.005f;

  private void Start()
  {
    hp = maxHp;
  }
  private void Update()
  {
    // Transform oldParent = transform.parent;
    // transform.parent = null;
    // transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
    // transform.parent = oldParent;
    if ((transform.parent.localScale.x < 0 && transform.localScale.x > 0) || (transform.parent.localScale.x > 0 && transform.localScale.x < 0))
    {
      transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    hpImage.fillAmount = hp / maxHp;
    if (hpEffectImage.fillAmount > hpImage.fillAmount)
    {
      hpEffectImage.fillAmount = hpEffectImage.fillAmount - hurtSpeed;
    }
    else
    {
      hpEffectImage.fillAmount = hpImage.fillAmount;
    }
  }

}
