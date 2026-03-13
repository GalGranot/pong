using TMPro;
using UnityEngine;
public class ScoreText : MonoBehaviour {
    [SerializeField] TextMeshProUGUI score_text;

    void OnEnable() => GameManager.on_score_change += UpdateScoreText;
    void OnDisable() => GameManager.on_score_change -= UpdateScoreText;

    void Start() {
        UpdateScoreText(0);
    }

    void UpdateScoreText(uint score) {
        score_text.text = $"Score: {score}";
    }
}