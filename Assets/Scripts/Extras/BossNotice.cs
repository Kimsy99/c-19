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
    LevelManager.Instance.IntroBoss(boss1);
    // Debug.Log("trigger enter");
    // bossL2Warning.SetActive(true);
    // spawner.startSpawn = true;
    // cameraController.secondaryTarget = boss1.transform;
    // cameraController.primaryTargetWeightage = 0;
    StartCoroutine(EndIntro());
    // cameraController.cameraTargetWeightage = 3;
  }
  private IEnumerator EndIntro()
  {
    yield return new WaitForSeconds(4);
    LevelManager.Instance.InitBossHealthBar();
    // bossL2Warning.SetActive(false);
    // cameraController.primaryTargetWeightage = 1;
    // cameraController.camSize = 6;
  }
}
