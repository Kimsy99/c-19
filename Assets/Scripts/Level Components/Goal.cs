using UnityEngine;

public class Goal : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collision)
	{
		LevelManager.Instance.SaveData();
		SceneLoader.Instance.data = LevelManager.Instance.levelNumber;
		SceneLoader.Instance.LoadScene("LevelComplete");
	}
}
