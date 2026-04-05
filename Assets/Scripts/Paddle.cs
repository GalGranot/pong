using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class Paddle : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float move_speed;
    [SerializeField] float walls_abs_x_pos;

    enum Direction { Left, Right, None }
    Direction dir = Direction.None;

    RigidbodyConstraints2D rb_constraints;

    void Update() {
        if (Keyboard.current.dKey.isPressed) {
            dir = Direction.Right;
        }
        else if (Keyboard.current.aKey.isPressed) {
            dir = Direction.Left;
        }
    }

    void FixedUpdate() {
        var pos = rb.position;
        if (Direction.None != dir) {
            int dir_sign = Direction.Right == dir ? 1 : -1;
            pos.x += move_speed * dir_sign;
            dir = Direction.None;
        }
        pos.x = Mathf.Clamp(pos.x, -walls_abs_x_pos, walls_abs_x_pos);
        rb.MovePosition(pos);
    }

    //! FIXME rmv?
    // void OnCollisionEnter2D(Collision2D collision) {
    //     GameObject other = collision.gameObject;
    // }

    void OnValidate() {
        if (move_speed <= 0f) Debug.LogError("Move speed must be > 0");
    }


    void OnEnable() {
        GameManager.on_game_over += freeze;
        GameManager.on_restart += unfreeze;
    }

    void OnDisable() {
        GameManager.on_game_over -= freeze;
        GameManager.on_restart -= unfreeze;
    }

    void freeze() {
        rb_constraints = rb.constraints;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void unfreeze() {
        rb.constraints = rb_constraints;
    }
}
