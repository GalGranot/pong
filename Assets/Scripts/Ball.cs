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

    void FixedUpdate() {
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, max_velocity_magnitude);
        if(MathF.Abs(rb.linearVelocity.y) < min_y_speed) {
            var v = rb.linearVelocity;
            v.y = min_y_speed * MathF.Sign(v.y);
            rb.linearVelocity = v;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Paddle")) {
            var v = rb.linearVelocity;
            float hit_position = transform.position.y - other.transform.position.y; 
            v.y *= hit_position * angle_factor;
            v.x *= hit_position * angle_factor;
            rb.linearVelocity = v;
        }
    }
}