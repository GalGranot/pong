using UnityEngine;
using TMPro;
public class GameOverText : MonoBehaviour {

    /*=============================================================================
    * Class Variables
    =============================================================================*/
    public TextMeshProUGUI game_over_text;
    GameManager gm;

    /*=============================================================================
    * Unity Callbacks 
    =============================================================================*/
    void Awake() {

    }

    void Start() {
        gm = GameManager.Instance;

        game_over_text = GetComponent<TextMeshProUGUI>();
        int score = 7; //! FIXME: 
        game_over_text.text = "Game over! Score: " + score;
    }

    // void Update() {

    // }

    void OnValidate() {

    }

    /*=============================================================================
    * Class Methods
    =============================================================================*/
}
