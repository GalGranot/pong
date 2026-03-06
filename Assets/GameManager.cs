using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;
public class GameManager : MonoBehaviour {

    /*=============================================================================
    * Class Variables
    =============================================================================*/
    public float upper_vertical_border;
    public float bottom_border = -4.2f;
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

    void OnValidate() {
        Debug.Assert(bottom_border < 0);
    }

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
