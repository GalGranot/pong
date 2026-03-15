using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    enum GameState {
        MainMenu,
        MainGame,
    }
    public static GameManager Instance;
    [SerializeField] GameState state = GameState.MainMenu;
    [SerializeField] uint score = 0;

    public static Action<uint> on_score_change;
    public static Action on_game_over;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        EnterState(GameState.MainMenu);
    }

    void EnterState(GameState next_state) {
        print($"Entering state {next_state}");
        state = next_state;
        switch(state) {
        case GameState.MainMenu: 
            EnterMainMenu();
            break;
        case GameState.MainGame:
            EnterGame();
            break;
        default:
            Debug.LogError("Entered invalid game state");
            break;
        }
    }

    void EnterMainMenu() {
        
    }

    public void EnterGameForButton() {
        EnterState(GameState.MainGame);
    }

    void EnterGame() {
        print("would be cool to add a countdown here");
        SceneManager.LoadScene("MainGame");
    }

    void UpdateScore(uint new_score) {
        score = new_score;
        on_score_change?.Invoke(score);
    }

    public void IncrementScore() {
        UpdateScore(score + 1);
    }

    public void TriggerGameOver() {
        Time.timeScale = 0f;
    }
}