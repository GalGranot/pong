using TMPro;
using UnityEngine;
public class ScoreText : MonoBehaviour {
    [SerializeField] TextMeshProUGUI text;

    void update_text(uint score) {
        text.text = $"Score: {score}";
    }

    void OnEnable() {
        GameManager.on_score_change += update_text;
    }

    void OnDisable() {
        GameManager.on_score_change -= update_text;
    }
}
