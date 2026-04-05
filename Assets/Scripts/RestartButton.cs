using UnityEngine;
using UnityEngine.UI;
public class RestartButton : MonoBehaviour {
    public void restart() {
        GameManager.instance.init_game_from_game_over();
    }
}
