using UnityEngine;
public class GameOverObjects : MonoBehaviour {
    void Start() {
        GameManager.Instance.game_over_objects = gameObject;
        gameObject.SetActive(false);
    }
}