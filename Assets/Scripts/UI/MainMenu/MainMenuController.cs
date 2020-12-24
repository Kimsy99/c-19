using UnityEngine;
 
public class MainMenuController : MonoBehaviour
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

	public void Level1()
	{
	   
	}

	public void Level2()
	{

	}

	public void Level3()
	{

	}

	public void Level4()
	{
		SceneLoader.Instance.LoadScene("Level 4");
	}

	public void Level5()
	{

	}
}