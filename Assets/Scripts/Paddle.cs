using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class Paddle : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [Range(3f, 20f), SerializeField] float speed;
    [SerializeField] float x_bound;
    float move = 0f;

    void Update() {
        move = 0f;
        if(Keyboard.current.aKey.isPressed) move -= 1f;
        if(Keyboard.current.sKey.isPressed) move += 1f;
    }

    void FixedUpdate() {
        if(move == 0f) return;
        Vector2 new_position = rb.position + move * speed * Time.fixedDeltaTime * Vector2.right;
        new_position.x = Math.Clamp(new_position.x, -x_bound, x_bound);
        rb.MovePosition(new_position);
    }
}