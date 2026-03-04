using TMPro;
using UnityEngine;
public class GameOverText : MonoBehaviour {
    public TextMeshProUGUI game_over_text;
    GameManager gm;
    void Start() {
        gm = GameManager.Instance;

        game_over_text = GetComponent<TextMeshProUGUI>();
        int score = gm.score;
        game_over_text.text = "Game over! Score: " + score;
    }

    void Update() {

    }
}