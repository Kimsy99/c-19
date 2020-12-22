using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Movable2D
{
  private BossHealth boss1;
  private NPCHurtOnCollide colliderNPC;
  // Start is called before the first frame update
  void Start()
  {
    boss1 = GetComponent<BossHealth>();
    colliderNPC = GetComponent<NPCHurtOnCollide>();
    boss1.OnDie += dead; //action
  }

  private void dead()
  {
    Speed = 0;
    colliderNPC.enabled = false;
    LevelManager.Instance.ExitBossMode();
    AudioManager.Instance.Stop(AudioEnum.BossTheme);
    Destroy(GetComponent<BoxCollider2D>());

  }
  // Update is called once per frame
  void Update()
  {

  }
}
