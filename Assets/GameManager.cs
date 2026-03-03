using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public float upper_vertical_border;
    public int score = 0;
    public TextMeshProUGUI text;
    void Start() {
        UpdateScoreText();
    }

    void UpdateScoreText() {
        text.text = "Score: " + score.ToString();
    }

    void Update() {

    }

    public void UpdateScore() {
        score++;
        UpdateScoreText();
    }
}