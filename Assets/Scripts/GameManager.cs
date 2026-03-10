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

    string current_scene;
    string previous_scene;

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

        current_scene = SceneManager.GetActiveScene().name;
        print($"Game manager loaded in scene {current_scene}");
    }

    void OnEnable() => Ball.on_ball_paddle_collision += UpdateScore;
    void OnDisable() => Ball.on_ball_paddle_collision -= UpdateScore;

    /*=============================================================================
    * Class Methods
    =============================================================================*/
    void ChangeScene(string scene) {
        print($"Game manager moving from scene {current_scene} to {scene}");
        SceneManager.LoadScene(scene);
        previous_scene = current_scene;
        current_scene = scene;
    }

    public void UpdateScore(int up_score) {
        score += up_score;
        on_score_change?.Invoke(score);
    }

    public void MoveToGameOver() {
        ChangeScene("GameOver");
    }

    public void RestartGame() {
        score = 0;
        ChangeScene(previous_scene);
    }

    public async void MoveToGameWithPerks() {
        on_move_to_game?.Invoke();
        await DoCountdown();
        score = 0;
        ChangeScene("GameWithPerks");
    }

    public async void MoveToBasicGame() {
        on_move_to_game?.Invoke();
        await DoCountdown();
        score = 0;
        ChangeScene("BasicGame");
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
