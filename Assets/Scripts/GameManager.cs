using System;
using System.Security.Cryptography;
using UnityEngine;
public class GameManager : MonoBehaviour {
    public static GameManager Instance;

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

    void UpdateScore(uint new_score) {
        score = new_score;
        on_score_change?.Invoke(score);
    }

    public void IncrementScore() {
        UpdateScore(score + 1);
    }
}