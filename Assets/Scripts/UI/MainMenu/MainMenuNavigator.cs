using UnityEngine;
 
public class MainMenuNavigator : MonoBehaviour
{
	[SerializeField] public GameObject mainMenu;
	[SerializeField] public GameObject levelSelectMenu;
	[SerializeField] public GameObject Story;
	[SerializeField] public GameObject Background;

	//public void Foo()
	//{
	//	mainMenu.SetActive(false);
	//	Background.SetActive(false);
	//	Story.SetActive(true);
	//}

	public void Play()
	{
		mainMenu.SetActive(false);
		levelSelectMenu.SetActive(true);
	}

	public void Back()
	{
		mainMenu.SetActive(true);
		levelSelectMenu.SetActive(false);
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void GoToLevel(string levelName)
	{
		SceneLoader.Instance.LoadScene(levelName);
	}
}
