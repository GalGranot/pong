using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    enum GameState {
        MainMenu,
        MainGame,
        GameOver,
    }
    public static GameManager Instance;
    [SerializeField] GameState state = GameState.MainMenu;
    [SerializeField] uint score = 0;

    public GameObject game_over_objects;

    public static Action<uint> on_score_change;
    int restarts = 0;
    // public static Action on_game_over; //! FIXME rmv this

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
        GameState previous_state = state;
        state = next_state;
        switch(state) {
        case GameState.MainMenu: 
            EnterMainMenu();
            break;
        case GameState.MainGame:
            EnterMainGame(previous_state);
            break;
        case GameState.GameOver:
            EnterGameOver();
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

    void EnterMainGame(GameState previous_state) {
        restarts += 1;
        print($"Restart number {restarts}");
        if(previous_state == GameState.MainGame) {
            game_over_objects.SetActive(false);
        }
        print("would be cool to add a countdown here");
        SceneManager.LoadScene("MainGame");
    }

    void EnterGameOver() {
        game_over_objects.SetActive(true);
    }

    void UpdateScore(uint new_score) {
        score = new_score;
        on_score_change?.Invoke(score);
    }

    public void IncrementScore() {
        UpdateScore(score + 1);
    }

    public void TriggerGameOver() {
        EnterState(GameState.GameOver);
    }
}