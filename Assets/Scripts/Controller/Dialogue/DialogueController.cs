using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : Singleton<DialogueController>
{
	private Ken ken;

	[SerializeField] private GameObject dialogBox;
	private Image image;
	private Image instructionImage; 
	private TextMeshProUGUI dialogText;
	private Queue<Sentence> sentences;
	[SerializeField] private Dialogue startingDialogue;

	private bool isDialogRunning;
	private Sentence currentSentence;
	private bool isTyping;

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
			StartCoroutine(DelayedStartDialogue(startingDialogue, 3.5F));
		}
	}

	void Update()
	{
		if (ken.health.IsDead)
			return;
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
		{
			if (isDialogRunning)
				DisplayNextSentence();
		}
	}

	private IEnumerator DelayedStartDialogue(Dialogue dialogue, float seconds)
	{
		yield return new WaitForSeconds(seconds);
		StartDialogue(dialogue);
	}

	public void StartDialogue(Dialogue dialogue)
	{
		isDialogRunning = true;
		dialogBox.SetActive(true);
		sentences.Clear();
		foreach (Sentence sentence in dialogue.sentences)
			sentences.Enqueue(sentence);
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (isTyping)
		{
			dialogText.text = currentSentence.text;
			isTyping = false;
			StopAllCoroutines();
			return;
		}
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		currentSentence = sentences.Dequeue();

		image.gameObject.SetActive(!currentSentence.isInstruction);
		instructionImage.gameObject.SetActive(currentSentence.isInstruction);
		Vector4 margin = dialogText.margin;
		margin.x = 110 * (currentSentence.isInstruction ? 0 : 1);
		margin.z = 110 * (currentSentence.isInstruction ? 1 : 0);
		dialogText.margin = margin;
		image.enabled = instructionImage.enabled = currentSentence.image != null;
		image.sprite = instructionImage.sprite = currentSentence.image;

		StopAllCoroutines();
		StartCoroutine(TypeSentence(currentSentence.text));
	}

	private IEnumerator TypeSentence(string text)
	{
		dialogText.text = "";
		isTyping = true;
		foreach (char letter in text.ToCharArray())
		{
			dialogText.text += letter;
			yield return new WaitForSeconds(0.025F);
		}
		isTyping = false;
	}

	void EndDialogue()
	{
		isDialogRunning = false;
		LevelManager.Instance.CanPlayerMove = true;
		dialogBox.SetActive(false);
	}
}
