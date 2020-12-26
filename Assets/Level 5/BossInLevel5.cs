using UnityEngine;

public class BossInLevel5 : MonoBehaviour
{
    private NPC npc;
    [SerializeField] private DoorKeyInLevel5[] kidsToSpawn = null;

    // Start is called before the first frame update
    void Awake()
    {
        npc = GetComponent<NPC>();
    }

    void Start()
    {
        npc.health.OnDie += SpawnKids;
    }

    // Update is called once per frame
    void SpawnKids()
    {
        AudioManager.Instance.Stop(AudioEnum.BossTheme);
        foreach (DoorKeyInLevel5 doorkey in kidsToSpawn)
        {
            Vector2 randomVar = new Vector2(Random.Range(-0.5F, 0.5F), Random.Range(-0.5F, 0.5F));
            Instantiate(doorkey, (Vector2)transform.position + randomVar, Quaternion.identity);
        }
    }
}
