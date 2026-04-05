using TMPro;
using UnityEngine;
public class GameOverText : MonoBehaviour {
    [SerializeField] TextMeshProUGUI text;

    void Start() {
        uint score = GameManager.instance.score;
        text.text = $"Game Over!\nScore: {score}";
    }
}