using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public float upper_vertical_border;
    public float left_score_border = -8.7f;
    public int score = 0;
    public TextMeshProUGUI score_text;

    public void MoveToGameOver() {
        SceneManager.LoadScene("GameOver");
    }

    public void MoveToGame() {
        score = 0;
        SceneManager.LoadScene("MainGame");
    }

    void OnValidate() {
        Debug.Assert(left_score_border < 0);
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

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