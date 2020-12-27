using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
	private Ken ken;

	[SerializeField] private GameObject dialogBox;
	private Image image;
	private Image instructionImage; 
	private TextMeshProUGUI dialogText;
	private Queue<Sentence> sentences;
	[SerializeField] private Dialogue startingDialogue;

	// Start is called before the first frame update
	protected override void Awake()
	{
		base.Awake();
		ken = FindObjectOfType<Ken>();
		image = dialogBox.transform.Find("Image").GetComponent<Image>();
		instructionImage = dialogBox.transform.Find("InstructionImage").GetComponent<Image>();
		dialogText = dialogBox.GetComponentInChildren<TextMeshProUGUI>();
		sentences = new Queue<Sentence>();

	}

	void Start()
	{
		ken.health.OnDie += EndDialogue;
		if (startingDialogue != null)
		{
			LevelManager.Instance.CanPlayerMove = false;
			StartCoroutine(DelayedStartDialogue(startingDialogue, 0.5F));
		}
	}

	void Update()
	{
		if (ken.health.IsDead)
			return;
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
			DisplayNextSentence();
	}

	private IEnumerator DelayedStartDialogue(Dialogue dialogue, float seconds)
	{
		yield return new WaitForSeconds(seconds);
		StartDialogue(dialogue);
	}

	public void StartDialogue(Dialogue dialogue)
	{
		dialogBox.SetActive(true);
		sentences.Clear();
		foreach (Sentence sentence in dialogue.sentences)
			sentences.Enqueue(sentence);
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		Sentence sentence = sentences.Dequeue();

		image.gameObject.SetActive(!sentence.isInstruction);
		instructionImage.gameObject.SetActive(sentence.isInstruction);
		Vector4 margin = dialogText.margin;
		margin.x = 110 * (sentence.isInstruction ? 0 : 1);
		margin.z = 110 * (sentence.isInstruction ? 1 : 0);
		dialogText.margin = margin;
		image.enabled = instructionImage.enabled = sentence.image != null;
		image.sprite = instructionImage.sprite = sentence.image;

		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence.text));
	}

	private IEnumerator TypeSentence(string text)
	{
		dialogText.text = "";
		foreach (char letter in text.ToCharArray())
		{
			dialogText.text += letter;
			yield return new WaitForSeconds(0.025F);
		}
	}

	void EndDialogue()
	{
		LevelManager.Instance.CanPlayerMove = true;
		dialogBox.SetActive(false);
	}
}
