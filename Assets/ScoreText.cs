using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class ScoreText : MonoBehaviour {

    /*=============================================================================
    * Class Variables
    =============================================================================*/
    TextMeshProUGUI text;

    /*=============================================================================
    * Unity Callbacks 
    =============================================================================*/
    void Start() {
        text = GetComponent<TextMeshProUGUI>();
        UpdateScoreText(0);
    }

    void OnEnable() => GameManager.on_score_change += UpdateScoreText;
    void OnDisable() => GameManager.on_score_change -= UpdateScoreText;

    /*=============================================================================
    * Class Methods
    =============================================================================*/
    void UpdateScoreText(int score) {
        text.text = $"Score: {score}";
    }

}
