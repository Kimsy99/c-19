using UnityEngine;

public class MissionDoor : Door
{
    private bool missionCompleted = false;

    public void CompleteMission()
    {
        missionCompleted = true;
        unlocked = true;
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!missionCompleted)
            {
                // openDoorRequirement.SetActive(true);
            }
        }
    }
}
