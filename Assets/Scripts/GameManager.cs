using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public static GameManager instance { get; private set; }
    public uint score { get; private set; } = 0;

    [SerializeField] GameObject hud;
    [SerializeField] GameObject game_over_text;
    [SerializeField] GameObject restart_button;

    public static event Action on_score_change;
    public static event Action on_game_over;
    public static event Action on_restart;

    void Awake() {
        instance = this;
    }

    void Start() {
        hud.SetActive(true);
        game_over_text.SetActive(false);
        restart_button.SetActive(false);
    }

    void OnEnable() {
        Ball.on_score += increment_score;
        Ball.on_out_of_bounds += game_over;
    }

    void OnDisable() {
        Ball.on_score -= increment_score;
        Ball.on_out_of_bounds -= game_over;
    }

    void change_score(uint new_score) {
        score = new_score;
        on_score_change?.Invoke();
    }

    void increment_score() => change_score(score + 1);

    void game_over() {
        game_over_text.SetActive(true);
        restart_button.SetActive(true);
        on_game_over?.Invoke();
    }

    public void restart_game() {
        on_restart?.Invoke();
        SceneManager.LoadScene("MainGame");
    }
}
