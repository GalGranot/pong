using UnityEngine;
public class Restart : MonoBehaviour {
    GameManager gm;
    void Start() {
        gm = GameObject
            .FindWithTag("GameManager")
            .GetComponent<GameManager>();
    }

    void Update() {

    }

    public void RestartGame() {
        gm.MoveToGame();
    }
}