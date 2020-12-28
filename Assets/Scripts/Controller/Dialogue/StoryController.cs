using System.Collections;
using UnityEngine;
using TMPro;

public class StoryController : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI storyText;

	[TextArea(3, 5)]
	[SerializeField] private string[] paragraphs;
	private int paragraphIndex = -1;

	private string currentParagraph;
	private bool isTyping;

	[SerializeField] private string levelName;
	[SerializeField] private GameObject pressAnyKeyToContinue;

	void Start()
	{
		Invoke(nameof(DisplayNextSentence), 3);
	}

	void Update()
	{
		if (Input.anyKeyDown)
			DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (isTyping)
		{
			storyText.text = currentParagraph;
			isTyping = false;
			StopAllCoroutines();
			return;
		}
		if (paragraphIndex == paragraphs.Length - 1)
		{
			EndDialogue();
			return;
		}

		currentParagraph = paragraphs[++paragraphIndex];

		StopAllCoroutines();
		StartCoroutine(TypeSentence());
	}

	private IEnumerator TypeSentence()
	{
		storyText.text = "";
		isTyping = true;
		foreach (char letter in currentParagraph.ToCharArray())
		{
			storyText.text += letter;
			yield return new WaitForSeconds(0.025F);
		}
		isTyping = false;
	}

	void EndDialogue()
	{
		storyText.text = "";
		SceneLoader.Instance.LoadScene(levelName);
		pressAnyKeyToContinue.SetActive(false);
	}
}
