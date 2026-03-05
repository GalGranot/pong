using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class GameManager : MonoBehaviour {

    /*=============================================================================
    * Class Variables
    =============================================================================*/
    public float upper_vertical_border;
    public float bottom_border = -4.2f;
    public int score = 0;

    public TextMeshProUGUI score_text;
    public TextMeshProUGUI countdown_text;

    public static GameManager Instance;

    /*=============================================================================
    * Unity Callbacks 
    =============================================================================*/
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
    }

    // void Update() {

    // }

    void OnValidate() {
        Debug.Assert(bottom_border < 0);
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

    public void MoveToBasicGame() {
        score = 0;
        SceneManager.LoadScene("BasicGame");
    }

    public async Task DoCountdown() {
        countdown_text.text = "Use A/S to move";
        countdown_text.gameObject.SetActive(true);

        for (int i = 3; i > 0; i--) {

        }

        await Task.Delay(3000);
        countdown_text.text = "3";
        await Task.Delay(1000);

        countdown_text.text = "2";
        await Task.Delay(1000);

        countdown_text.text = "1";
        await Task.Delay(1000);

        countdown_text.text = "GO!";
        await Task.Delay(500);
        countdown_text.gameObject.SetActive(false);
    }

    public async void DisableMainMenuText() {
        await AsyncDisableMainMenuText();
        MoveToBasicGame();
    }

    public async Task AsyncDisableMainMenuText() {
        var main_menu_text = GameObject.FindWithTag("MainMenuText");
        if (main_menu_text is null) {
            Debug.Log("Game manager could not find main menu text");
        }
        Destroy(main_menu_text);
        await DoCountdown();
    }

}
