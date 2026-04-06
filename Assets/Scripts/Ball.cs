using System;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float init_min_vx;
    [SerializeField] float init_max_vx;
    [SerializeField] float init_min_vy;
    [SerializeField] float init_max_vy;
    Resettable resettable;

    public static event Action on_score;
    public static event Action on_out_of_bounds;

    void Awake() {
        resettable = GetComponent<Resettable>();
    }

    void Start() {
        set_random_start_velocity();
    }

    void set_random_start_velocity() {
        float vx = UnityEngine.Random.Range(init_min_vx, init_max_vx);
        float vy = UnityEngine.Random.Range(init_min_vy, init_max_vy);
        rb.linearVelocity = new Vector2(vx, vy);
    }

    void ball_reset() {
        resettable.reset_to_start();
        set_random_start_velocity();
    }

    void OnEnable() {
        GameManager.on_game_over += resettable.freeze;
        GameManager.on_restart += ball_reset;
    }

    void OnDisable() {
        GameManager.on_game_over -= resettable.freeze;
        GameManager.on_restart -= ball_reset;
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
        if (init_min_vx == 0f ||
            init_max_vx == 0f ||
            init_min_vy == 0f ||
            init_max_vy == 0f
        ) {
            Debug.LogError("initial ball speeds must be set");
        }
    }
}
