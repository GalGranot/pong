using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public static GameManager instance { get; private set; }
    public uint score { get; private set; } = 0;

    [SerializeField] GameObject play_game_objects;
    [SerializeField] GameObject welcome_screen_objects;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject game_over_objects;

    public static event Action<uint> on_score_change;
    public static event Action on_game_over;
    public static event Action on_restart;

    void Awake() {
        instance = this;
    }

    void Start() {
        init_welcome_screen();
    }

    void OnEnable() {
        Ball.on_score += increment_score;
        Ball.on_out_of_bounds += init_game_over;
    }

    void OnDisable() {
        Ball.on_score -= increment_score;
        Ball.on_out_of_bounds -= init_game_over;
    }

    /*=============================================================================
    * Transitions
    =============================================================================*/
    void init_welcome_screen() {
        welcome_screen_objects.SetActive(true);
    }

    public void init_game_from_welcome_screen() {
        welcome_screen_objects.SetActive(false);
        play_game_objects.SetActive(true);
        hud.SetActive(true);
    }

    void init_game_over() {
        play_game_objects.SetActive(false);
        hud.SetActive(false);
        game_over_objects.SetActive(true);
        on_game_over?.Invoke();
    }

    public void init_game_from_game_over() {
        game_over_objects.SetActive(false);
        play_game_objects.SetActive(true);
        hud.SetActive(true);
        update_score(0);
        on_restart?.Invoke();
    }


    void update_score(uint new_score) {
        score = new_score;
        on_score_change?.Invoke(score);
    }

    void increment_score() => update_score(score + 1);
}
