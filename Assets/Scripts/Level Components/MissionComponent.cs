using UnityEngine;

public class MissionComponent : Collectable
{
    [Header("Door to be locked")]
    [SerializeField] private MissionDoor door;

    [Header("Hint Canvas")]
    [SerializeField] private GameObject stealInfo;
    [SerializeField] private GameObject exitOpened;

    private bool missionCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (!missionCompleted)
            {
                stealInfo.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!missionCompleted)
            {
                stealInfo.SetActive(false);
            }
        }
    }

    protected override void Collect()
    {
        door.CompleteMission();
        missionCompleted = true;

        stealInfo.SetActive(false);
        exitOpened.SetActive(true);
    }
}
