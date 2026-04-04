using UnityEngine;
using UnityEngine.InputSystem;
public class Paddle : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float move_speed;

    Vector2 after_move_position(int dir) {
        var pos = rb.position;
        pos.x += move_speed * dir;
        return pos;
    }

    void Update() {
        if(Keyboard.current.dKey.isPressed) {
            rb.MovePosition(after_move_position(1));
        } else if(Keyboard.current.aKey.isPressed) {
            rb.MovePosition(after_move_position(-1));
        }
    }

    void OnValidate() {
        if(move_speed <= 0f) Debug.LogError("Move speed must be > 0");
    }
}