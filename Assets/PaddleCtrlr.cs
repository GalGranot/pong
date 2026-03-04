using UnityEngine;
using UnityEngine.InputSystem;
public class PaddleCtrlr : MonoBehaviour {
    public float speed;
    GameManager gm;
    public Key down_key;
    public Key up_key;
    public Rigidbody2D rb;
    public float bounce_strength;
    float move;
    
    void Start() {
        gm = GameManager.Instance;
    }

    void OnValidate() {
        Debug.Assert(speed > 0f);
        Debug.Assert(bounce_strength > 0f);
    }

    void Update() {
        var y = transform.position.y;
        move = 0f;
            if(Keyboard.current[up_key].isPressed) move += 1f;
            if(Keyboard.current[down_key].isPressed) move -= 1f;
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + Vector2.up * speed * move * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //! FIXME add some cool paddle bounce of walls as a perk?
        // Debug.Log("Paddle collision");
        // if(collision.gameObject.CompareTag("BorderWalls")) {
        //     float bounce_dir = transform.position.y > 0 ? -1f : 1f;
        //     rb.AddForce(transform.up * bounce_dir * bounce_strength);
        // }
    }
}