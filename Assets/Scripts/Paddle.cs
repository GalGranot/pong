using UnityEngine;
using UnityEngine.InputSystem;
public class Paddle : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float move_speed;

    enum Direction { Left, Right, None }
    Direction dir = Direction.None;

    void Update() {
        if (Keyboard.current.dKey.isPressed) {
            dir = Direction.Right;
        }
        else if (Keyboard.current.aKey.isPressed) {
            dir = Direction.Left;
        }
    }

    void FixedUpdate() {
        if (Direction.None == dir) {
            return;
        }
        int dir_sign = Direction.Right == dir ? 1 : -1;
        var pos = rb.position;
        pos.x += move_speed * dir_sign;
        rb.MovePosition(pos);

        dir = Direction.None;
    }

    //! FIXME rmv?
    // void OnCollisionEnter2D(Collision2D collision) {
    //     GameObject other = collision.gameObject;
    // }

    void OnValidate() {
        if (move_speed <= 0f) Debug.LogError("Move speed must be > 0");
    }
}
