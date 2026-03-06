using UnityEngine;
using TMPro;
public class GameOverText : MonoBehaviour {

    /*=============================================================================
    * Class Variables
    =============================================================================*/
    TextMeshProUGUI text;

    /*=============================================================================
    * Unity Callbacks 
    =============================================================================*/

    void Start() {
        text = GetComponent<TextMeshProUGUI>();
        int score = GameManager.Instance.Score;
        text.text = $"Game over! Score: {score}";
    }

    /*=============================================================================
    * Class Methods
    =============================================================================*/

}
