using System;
using UnityEngine;

public class Health : MonoBehaviour
{
  public float hp;
  [SerializeField] protected float maxHp;
  [HideInInspector] public float invulnerabilityTimer = 0;

  public Action OnDie;

  public virtual float Hp
  {
    get => hp;
    set
    {
      hp = Mathf.Clamp(value, 0, maxHp);
      if (hp == 0)
        OnDie?.Invoke();
    }
  }

  // Use this for initialization
  protected virtual void Awake()
  {
    Hp = maxHp;
  }

  protected virtual void Update()
  {
    invulnerabilityTimer = Mathf.Max(invulnerabilityTimer - Time.deltaTime, 0);
  }

  public virtual bool Damage(float damage, float invulnerabilityTime = 0)
  {
    if (!IsInvulnerable)
    {
      Hp -= damage;
      invulnerabilityTimer = invulnerabilityTime;
      return true;
    }
    return false;
  }

  public bool IsInvulnerable
  {
    get => invulnerabilityTimer > 0;
  }

  public bool IsDead
  {
    get => Hp == 0;
  }
}
