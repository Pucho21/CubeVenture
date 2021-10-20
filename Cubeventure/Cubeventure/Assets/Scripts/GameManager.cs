﻿using System.Collections;
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
    public int enemiesKilledCount;

    public int time;
    private float gameTimeElapsed;

    public int highScore;

    public GameObject pausePanel;
    public GameObject endPanel;
    bool gamePaused;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        gameTimeElapsed += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
                ResumeGame();
            else
                PauseGame();
        }

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
    public void EnemyKilled()
    {
        enemiesKilledCount++;
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

    public void EndGame()
    {        
        endPanel.GetComponent<EndPanel>().SetEndPanelValues(collectedStarsCount,enemiesKilledCount,collectedCoinsCount,Mathf.RoundToInt(gameTimeElapsed),highScore);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
}
