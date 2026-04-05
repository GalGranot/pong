using System;
using UnityEngine;
public class Ball : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float init_vx;
    [SerializeField] float init_vy;

    Resettable resettable;

    public static event Action on_score;
    public static event Action on_out_of_bounds;

    void Awake() {
        resettable = GetComponent<Resettable>();
    }

    void Start() {
        rb.linearVelocity = new Vector2(init_vx, init_vy);
    }

    void OnEnable() {
        GameManager.on_game_over += resettable.freeze;
        GameManager.on_restart += resettable.reset_to_start;
    }

    void OnDisable() {
        GameManager.on_game_over -= resettable.freeze;
        GameManager.on_restart -= resettable.reset_to_start;
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
        if (init_vx <= 0f || init_vy <= 0f) {
            Debug.LogError("initial ball speeds must be > 0");
        }
    }
}
