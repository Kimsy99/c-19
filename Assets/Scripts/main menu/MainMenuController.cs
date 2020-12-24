using UnityEngine;
 
public class MainMenuController : MonoBehaviour
{
	public GameObject mainMenu;
	public GameObject optionsMenu;

	public void Play()
	{
		mainMenu.SetActive(false);
		optionsMenu.SetActive(true);
	}

	public void Back()
	{
		mainMenu.SetActive(true);
		optionsMenu.SetActive(false);
	}

	public void Exit()
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

	}

	public void Level5()
	{

	}
}
