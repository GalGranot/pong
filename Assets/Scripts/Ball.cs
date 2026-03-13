using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;

    void Start() {
        print("Ball using initial set speed - fix this later");
        rb.linearVelocity = new Vector2(7f, 8f);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject other = collision.gameObject;
        print($"ball collision with {other.tag}");
    }
}