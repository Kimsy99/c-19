﻿using TMPro;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI label;
	[SerializeField] private GameObject pressAnyKeyToContinue;

	void Awake()
	{
		label.text = "Level " + SceneLoader.Instance.data + " Complete!";
	}

	void Update()
	{
		if (Input.anyKeyDown)
		{
			if (label.text.Equals("Level 5 Complete!"))
				SceneLoader.Instance.LoadScene("Ending");
			else
				SceneLoader.Instance.LoadScene("MainMenu");
			label.gameObject.SetActive(false);
			pressAnyKeyToContinue.SetActive(false);
		}
	}
}