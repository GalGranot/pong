/*=============================================================================
* Includes
=============================================================================*/
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

/*=============================================================================
* Class Variables
=============================================================================*/
public float upper_vertical_border;
public float left_score_border = -8.7f;
public int score = 0;
public TextMeshProUGUI score_text;

public static GameManager Instance;

/*=============================================================================
* Unity Callbacks 
=============================================================================*/

void Awake() {
    if(Instance != null && Instance != this) {
        Destroy(gameObject);
        return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
}

void Start() {
    UpdateScoreText();
}

// void Update() {

// }

void OnValidate() {
    Debug.Assert(left_score_border < 0);
}

/*=============================================================================
* Class Methods
=============================================================================*/
public void UpdateScore() {
    score++;
    UpdateScoreText();
}

public void UpdateScoreText() {
    score_text.text = "Score: " + score.ToString();
}

public void MoveToGameOver() {
    SceneManager.LoadScene("GameOver");
}

public void MoveToGame() {
    score = 0;
    SceneManager.LoadScene("MainGame");
}

}