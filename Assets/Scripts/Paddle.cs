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

    void move_right() {
        rb.MovePosition(after_move_position(1));
    }

    void move_left() {
        rb.MovePosition(after_move_position(-1));
    }

    void Update() {
        if(Keyboard.current.dKey.isPressed) {
            move_right();
        } else if(Keyboard.current.aKey.isPressed) {
            move_left();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject other = collision.gameObject;
    }

    void OnValidate() {
        if(move_speed <= 0f) Debug.LogError("Move speed must be > 0");
    }
}