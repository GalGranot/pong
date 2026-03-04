using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour {
    GameManager gm;
    void Start() {
        gm = GameManager.Instance;
        gm.score_text = GetComponent<TextMeshProUGUI>();
        gm.UpdateScoreText();
    }
}
