using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject pauseGameUI;
    [SerializeField] GameObject pauseGameButton;
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject controlTutorialUI;

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
        controlTutorialUI.SetActive(isGameStarted);

        /*pauseGameButton.SetActive(isGameStarted);
        mainMenuUI.SetActive(!isGameStarted);*/
    }

    public void OnStartCutscene(bool isCutSceneStarted)
    {
        mainMenuUI.SetActive(!isCutSceneStarted);
    }

    public void StartGame()
    {
        //GameManager.Instance.StartGame();
        pauseGameButton.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void StartCutScene()
    {
        GameManager.Instance.StartCutScene();
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

    public void ActivatePhotoAlbumTutorial()
    {
        GameManager.Instance.ActivatePhotoTutorial();
    }
}
