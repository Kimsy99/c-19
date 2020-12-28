using TMPro;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI label;

	void Awake()
	{
		label.text = "Level " + SceneLoader.Instance.data + " Complete!";
	}

	void Update()
	{
		if (Input.anyKeyDown)
			SceneLoader.Instance.LoadScene("MainMenu");
	}
}
