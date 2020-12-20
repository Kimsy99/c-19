using System;
using System.Collections;
using UnityEngine;

public class BossNotice : MonoBehaviour
{

  [SerializeField] private GameObject bossL2Warning;
  [SerializeField] private CameraController cameraController;
  [SerializeField] private BossSpawnZombie spawner;
  [SerializeField] private GameObject boss1;
  [SerializeField] private NPCHealth npcHealth;

  void Start()
  {
    // spawner = GameObject.Find("BossZombieSpawner").GetComponent<BossSpawnZombie>();
  }
  void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log("trigger enter");
    bossL2Warning.SetActive(true);
    spawner.startSpawn = true;
    cameraController.secondTarget = boss1.transform;
    cameraController.cameraTargetWeightage = 0;
    StartCoroutine(EndIntro());
    // cameraController.cameraTargetWeightage = 3;
  }
  private IEnumerator EndIntro()
  {
    yield return new WaitForSeconds(4);
    bossL2Warning.SetActive(false);
    cameraController.cameraTargetWeightage = 1;
    cameraController.camSize = 6;
  }
  public void BossInit()
  {
    // AudioManager.Instance.Stop(AudioEnum.Alarm);
    // AudioManager.Instance.Play(AudioEnum.Regenerate);
    StartCoroutine(InitBossHealth());
  }

  private IEnumerator InitBossHealth()
  {
    float timeElapsed = 0;
    while (true)
    {
      timeElapsed += Time.deltaTime;
      // healthBar.fillAmount = Mathf.Min(timeElapsed / 3.4F, 1);
      if (npcHealth.Hp != 0)
        break;
      yield return new WaitForEndOfFrame();
    }
    // boss.animator.SetTrigger(boss.nextPhaseTriggerParameter);
    // LevelManager.Instance.isBossIntro = false;
    // LevelManager.Instance.isBossReady = true;
    Debug.Log("asdfasd");
    // cameraController.cameraTargetWeightage = 1;
    // cameraController.camSize = 6;

  }
}
