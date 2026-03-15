using System;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float angle_factor;
    [SerializeField] float max_velocity_magnitude;
    [SerializeField] float min_y_speed;

    void Start() {
        print("Ball using initial set speed - fix this later");
        rb.linearVelocity = new Vector2(7f, 8f);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        var other = collision.gameObject;
        if(other.CompareTag("Paddle")) {
            PaddleCollision(collision);
        } else if(other.CompareTag("DeadZone")) {
            print("ball hit dead zone");
            GameManager.Instance.TriggerGameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
    }

    void PaddleCollision(Collider2D collision) {
        var v = rb.linearVelocity;
        if(v.y > 0) return;

        float paddle_width = collision.GetComponent<Collider2D>().bounds.size.x;
        float hit_offset = (transform.position.x - collision.transform.position.x) / (paddle_width / 2);
        if(
            (v.x < 0 && hit_offset > 0) || // ball moving left and hit right of paddle
            (v.x > 0 && hit_offset < 0) // ball moving right and hit left of paddle
        ) {
            v.x *= -1;
        }
        v.y *= -1;
        rb.linearVelocity = v.normalized * speed;
    }
}