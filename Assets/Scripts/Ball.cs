using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float angle_factor;

    void Start() {
        print("Ball using initial set speed - fix this later");
        rb.linearVelocity = new Vector2(7f, 8f);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Paddle")) {
            var v = rb.linearVelocity;
            float hit_position = transform.position.y - other.transform.position.y; 
            v.y *= hit_position * angle_factor;
            rb.linearVelocity = v;
        }
    }
}