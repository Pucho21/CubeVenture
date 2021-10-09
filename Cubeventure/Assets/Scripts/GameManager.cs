using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int starsCount;
    [HideInInspector]public int collectedStarsCount = 0;

    [Space]
    public int coinsCount;
    [HideInInspector] public int collectedCoinsCount = 0;

    public GameObject pausePanel;
    bool gamePaused;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        gamePaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene("MainMenu");
    }



    public void CoinCollected()
    {
        collectedCoinsCount++;
        InGameUIPanel.instance.UpdateCoinsCountText();
    }

    public void StarCollected()
    {
        collectedStarsCount++;
        InGameUIPanel.instance.UpdateStarsCountText();
    }
}
