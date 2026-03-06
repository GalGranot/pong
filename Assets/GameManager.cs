using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;
public class GameManager : MonoBehaviour {

    /*=============================================================================
    * Class Variables
    =============================================================================*/
    int score = 0;
    public int Score => score;

    public static GameManager Instance;
    public static Action<int> on_score_change;
    public static Action on_move_to_game;
    public static Action<string> on_countdown_tick;

    /*=============================================================================
    * Unity Callbacks 
    =============================================================================*/
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable() => Ball.on_ball_paddle_collision += UpdateScore;
    void OnDisable() => Ball.on_ball_paddle_collision -= UpdateScore;

    /*=============================================================================
    * Class Methods
    =============================================================================*/
    public void UpdateScore() {
        score++;
        on_score_change?.Invoke(score);
    }

    public void MoveToGameOver() {
        SceneManager.LoadScene("GameOver");
    }

    public void RestartGame() {
        score = 0;
        SceneManager.LoadScene("BasicGame");
    }

    public async void MoveToGameWithPerks() {
        on_move_to_game?.Invoke();
        await DoCountdown();
        score = 0;
        SceneManager.LoadScene("GameWithPerks");
    }

    public async void MoveToBasicGame() {
        on_move_to_game?.Invoke();
        await DoCountdown();
        score = 0;
        SceneManager.LoadScene("BasicGame");
    }

    public async Task DoCountdown() {
        on_countdown_tick?.Invoke("Use A/S to move");
        await Task.Delay(4000);

        for (int i = 3; i > 0; i--) {
            on_countdown_tick?.Invoke(i.ToString());
            await Task.Delay(1000);
        }
        on_countdown_tick?.Invoke("GO!");
        await Task.Delay(500);
    }
}
