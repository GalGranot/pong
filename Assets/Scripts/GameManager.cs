using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    enum GameState {
        MainMenu,
        Game,
    }
    public static GameManager Instance;
    [SerializeField] GameState state = GameState.MainMenu;
    [SerializeField] uint score = 0;

    public static Action<uint> on_score_change;

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
        state = next_state;
        switch(state) {
        case GameState.MainMenu: 
            EnterMainMenu();
            break;
        case GameState.Game:
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
        EnterState(GameState.Game);
    }

    void EnterGame() {
        SceneManager.LoadScene("MainGame");
    }

    void UpdateScore(uint new_score) {
        score = new_score;
        on_score_change?.Invoke(score);
    }

    public void IncrementScore() {
        UpdateScore(score + 1);
    }
}