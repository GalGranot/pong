using UnityEngine;
public class StartGameButton : MonoBehaviour {
    public void start_game() => GameManager.instance.init_game_from_welcome_screen();
}
