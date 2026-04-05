using UnityEngine;
using UnityEngine.UI;
public class RestartButton : MonoBehaviour {
    public void restart() {
        GameManager.instance.restart_game();
    }
}