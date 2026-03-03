using UnityEngine;
public class Ball : MonoBehaviour {
    public Rigidbody2D rb;

    void Start() {
        rb.linearVelocity = new Vector2(5, 6);
    }

    void Update() {

    }

    void FlipVertSpeed() {
        var v = rb.linearVelocity;
        v.y *= -1;
        rb.linearVelocity = v;
    }

    void FlipHorzSpeed() {
        var v = rb.linearVelocity;
        v.x *= -1;
        rb.linearVelocity = v;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("ball collision");
        if(collision.gameObject.CompareTag("BorderWalls")) {
            FlipVertSpeed();
        } else if(collision.gameObject.CompareTag("RightWall")) {
            FlipHorzSpeed();
        }
    }
}