using UnityEngine;
using UnityEngine.UI;
public class RestartButton : MonoBehaviour {
    public void restart() {
        print("hit restart button"); //! FIXME: rmv
        GameManager.instance.restart_game();
    }
}