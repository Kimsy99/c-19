using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialog;
	public Animator animator;
	public Queue<string> sentences;
	// Start is called before the first frame update
	void Start()
	{
		sentences = new Queue<string>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void StartDialogue(Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);
		nameText.text = dialogue.name;
		Debug.Log("start dialog ");
		sentences.Clear();
		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}
	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	private IEnumerator TypeSentence(string sentence)
	{
		dialog.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialog.text += letter;
			yield return new WaitForSeconds(0.05F);
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		Debug.Log("End of dialogue");
	}
}
