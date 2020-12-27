using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;

	void OnTriggerEnter2D(Collider2D collision)
	{
		LevelManager.Instance.CanPlayerMove = false;
		TriggerDialogue();
	}

	public void TriggerDialogue()
	{
		DialogueManager.Instance.StartDialogue(dialogue);
		Destroy(gameObject);
	}
}
