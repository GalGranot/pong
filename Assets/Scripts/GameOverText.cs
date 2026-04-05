using TMPro;
using UnityEngine;
public class GameOverText : MonoBehaviour {
    [SerializeField] TextMeshProUGUI text;

    void Start() {
        update_score();
    }

    void OnEnable() {
        update_score();
    }

    void update_score() {
        uint score = GameManager.instance.score;
        text.text = $"Game Over!\nScore: {score}";
    }
}
