using UnityEngine;
using UnityEngine.InputSystem;
public class Paddle : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    

    [Range(3f, 10f), SerializeField] float speed;
    float move = 0f;

    void Update() {
        move = 0f;
        if(Keyboard.current.aKey.isPressed) move -= 1f;
        if(Keyboard.current.sKey.isPressed) move += 1f;
    }

    void FixedUpdate() {
        if(move == 0f) return;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime * Vector2.right);
    }
}