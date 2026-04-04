using TMPro;
using UnityEngine;
public class ScoreText : MonoBehaviour {
    [SerializeField] TextMeshProUGUI text;

    void update_text() {
        text.text = $"Score: {GameManager.instance.score}";
    }
    
    void OnEnable() {
        GameManager.on_score_change += update_text;
    }

    void OnDisable() {
        GameManager.on_score_change -= update_text;
    }
}