using System;
using UnityEngine;
public class Ball : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float init_x_speed;
    [SerializeField] float init_y_speed;

    RigidbodyConstraints2D rb_constraints;

    public static event Action on_score;
    public static event Action on_out_of_bounds;

    void Start() {
        rb.linearVelocity = new Vector2(init_x_speed, init_y_speed);
    }

    void OnEnable() {
        GameManager.on_game_over += freeze;
        GameManager.on_restart += unfreeze;
    }

    void OnDisable() {
        GameManager.on_game_over -= freeze;
        GameManager.on_restart -= unfreeze;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject other = collision.gameObject;
        if (other.CompareTag("paddle")) {
            on_score?.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject other = collision.gameObject;
        if (other.CompareTag("bottom border")) {
            on_out_of_bounds?.Invoke();
        }
    }

    void OnValidate() {
        if (init_x_speed <= 0f || init_y_speed <= 0f) Debug.LogError("initial ball speeds must be > 0");
    }

    void freeze() {
        rb_constraints = rb.constraints;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    void unfreeze() {
        rb.constraints = rb_constraints;
    }
}
