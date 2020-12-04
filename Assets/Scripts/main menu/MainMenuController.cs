﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenuController : MonoBehaviour
{
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject optionsMenu;


    public void playGame()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
    public void level1()
    {
       
    }
    public void level2()
    {

    }
    public void level3()
    {

    }
    public void level4()
    {

    }
    public void level5()
    {

    }


}