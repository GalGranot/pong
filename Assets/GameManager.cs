using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public float upper_vertical_border;
    public int score = 0;
    public TextMeshProUGUI score_text;
    void Start() {
        UpdateScoreText();
    }


    void Update() {

    }

    public void UpdateScore() {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText() {
        score_text.text = "Score: " + score.ToString();
    }
}