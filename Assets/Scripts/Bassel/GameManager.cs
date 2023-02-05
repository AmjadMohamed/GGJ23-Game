using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable] public class BoolGameEvent : UnityEvent<bool>{}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Events related variables")]
    // Pause variables
    public BoolGameEvent PauseGameEvent;
    private bool isGamePaused = false;
    
    // Start game variables
    public BoolGameEvent StartGameEvent;
    private bool isGameStarted = false;                 // becomes true when the player starts the game


    [Header("UI related variables")]
    // UI variables
    [SerializeField] GameObject GameUIGameObject;       // lives with the game from the start, not destroyed on scenes


    [Header("Management related variables")]
    [SerializeField] string MainLevelName = "Game Scene";
    [SerializeField] string StartUpLevelName = "Start up Scene";


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);

        // Creating and setting GameUI from prefab
        GameUIGameObject = Instantiate(GameUIGameObject);
        DontDestroyOnLoad(GameUIGameObject);
        GameUI gameUI = GameUIGameObject.GetComponent<GameUI>();
        if (gameUI != null)
        {
            PauseGameEvent.AddListener(gameUI.OnPauseGame);
            StartGameEvent.AddListener(gameUI.OnStartGame);
        }
    }

    private void Update()
    {
        // Pausing/Unpausing game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleGamePause();
        }        
    }

    public void ToggleGamePause()
    {
        if (!isGameStarted)
        {
            return;
        }
        isGamePaused = !isGamePaused;
        PauseGameEvent.Invoke(isGamePaused);
    }

    public void StartGame()
    {
        isGameStarted = true;
        StartGameEvent.Invoke(true);

        SceneManager.LoadScene(MainLevelName);
    }

    public void RestartGame()
    {
        StartGame();
    }

    public void BackToStartUpScene()
    {
        isGameStarted = false;
        StartGameEvent.Invoke(false);

        SceneManager.LoadScene(StartUpLevelName);
    }
}
