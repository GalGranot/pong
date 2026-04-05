using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public static GameManager instance { get; private set; }
    public uint score { get; private set; } = 0;

    [SerializeField] GameObject hud;
    [SerializeField] GameObject game_over_objects;

    public static event Action<uint> on_score_change;
    public static event Action on_game_over;
    public static event Action on_restart;

    void Awake() {
        instance = this;
    }

    void Start() {
        hud.SetActive(true);
        game_over_objects.SetActive(false);
    }

    void OnEnable() {
        Ball.on_score += increment_score;
        Ball.on_out_of_bounds += game_over;
    }

    void OnDisable() {
        Ball.on_score -= increment_score;
        Ball.on_out_of_bounds -= game_over;
    }

    void update_score(uint new_score) {
        score = new_score;
        on_score_change?.Invoke(score);
    }

    void increment_score() => update_score(score + 1);

    void game_over() {
        hud.SetActive(false);
        game_over_objects.SetActive(true);
        on_game_over?.Invoke();
    }

    public void restart_game() {
        on_restart?.Invoke();
        SceneManager.LoadScene("MainGame");
    }
}
