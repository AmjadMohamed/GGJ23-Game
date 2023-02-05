using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject pauseGameUI;
    [SerializeField] GameObject pauseGameButton;
    [SerializeField] GameObject mainMenuUI;

    private void Awake()
    {
        // On start pause game should be inactive
        pauseGameUI.SetActive(false);
    }

    public void OnPauseGame(bool isGamePause)
    {
        pauseGameUI.SetActive(isGamePause);
    }

    public void OnStartGame(bool isGameStarted)
    {
        pauseGameButton.SetActive(isGameStarted);
        mainMenuUI.SetActive(!isGameStarted);
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void TogglePauseGame()
    {
        GameManager.Instance.ToggleGamePause();
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
        pauseGameUI.SetActive(false);
    }

    public void BackToMainMenu()
    {
        GameManager.Instance.BackToStartUpScene();
        pauseGameUI.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
