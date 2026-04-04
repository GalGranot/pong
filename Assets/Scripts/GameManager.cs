using System;
using UnityEngine;
public class GameManager : MonoBehaviour {
    public static GameManager instance { get; private set; }
    public uint score { get; private set; } = 0;

    public static event Action on_score_change;

    void Awake() {
        instance = this;
    }

    void change_score(uint new_score) {
        score = new_score;
        on_score_change?.Invoke();
    }

    void increment_score() => change_score(score + 1);

    void OnEnable() {
        Ball.on_score += increment_score;
    }

    void OnDisable() {
        Ball.on_score -= increment_score;
    }
}