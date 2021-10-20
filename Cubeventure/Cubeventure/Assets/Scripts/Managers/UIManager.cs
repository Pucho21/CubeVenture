using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //Screen object variables
    public GameObject introUI;
    public GameObject loginUI;
    public GameObject mainMenuUI;
    public GameObject loginUserUI;
    public GameObject registerUserUI;
    public GameObject shopUI;
    public GameObject settingsUI;
    public GameObject scoreboardUI;
    //public GameObject userDataUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    private void Start()
    {
        if (UserInfoHolder.instance.IsUserLoggedIn())
        {
            MainMenu();
        }
    }

    public void clearScreen()
    {
        loginUI.SetActive(false);
        registerUserUI.SetActive(false);
        mainMenuUI.SetActive(false);
        introUI.SetActive(false);
        loginUserUI.SetActive(false);
        shopUI.SetActive(false);
        settingsUI.SetActive(false);
        scoreboardUI.SetActive(false);
        //userDataUI.SetActive(false);

    }

    //Functions to change the login screen UI
    public void LoginScreen() //Back button
    {
        clearScreen();
        loginUI.SetActive(true);
    }

    public void SettingsScreen()
    {
        clearScreen();
        settingsUI.SetActive(true);
    }

    public void ScoreboardScreen()
    {
        clearScreen();
        scoreboardUI.SetActive(true);
    }

    public void ShopScreen()
    {
        clearScreen();
        shopUI.SetActive(true);
    }

    public void RegisterUserScreen() // Register button
    {
        clearScreen();
        registerUserUI.SetActive(true);
    }
    public void LoginUserScreen() //Back button
    {
        clearScreen();
        loginUserUI.SetActive(true);
    }

    public void MainMenu()
    {
        clearScreen();
        mainMenuUI.SetActive(true);
    }

    public void introScreen()
    {
        clearScreen();
        introUI.SetActive(true);
    }

    /*
    public void UserDataScreen()
    {
        clearScreen();
        userDataUI.SetActive(true);
    }
    

    public void ScoreboardScreen()
    {
        clearScreen();
        scoreMenuUI.SetActive(true);
    }
    */

}
