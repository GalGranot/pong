using UnityEngine;
using UnityEngine.InputSystem;
public class PaddleCtrlr : MonoBehaviour {

    /*=============================================================================
    * Class Variables
    =============================================================================*/
    public float speed;
    GameManager gm;
    public Key down_key;
    public Key up_key;
    public Rigidbody2D rb;
    public float bounce_strength;
    float move;

    /*=============================================================================
    * Unity Callbacks 
    =============================================================================*/
    void Awake() {

    }

    void Start() {
        gm = GameManager.Instance;
    }

    void Update() {
        // var y = transform.position.y;
        move = 0f;
        if (Keyboard.current.aKey.isPressed) {
            move -= 1f;
        }
        if (Keyboard.current.sKey.isPressed) {
            move += 1f;
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime * Vector2.right);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //! FIXME add some cool paddle bounce of walls as a perk?
        // Debug.Log("Paddle collision");
        // if(collision.gameObject.CompareTag("BorderWalls")) {
        //     float bounce_dir = transform.position.y > 0 ? -1f : 1f;
        //     rb.AddForce(transform.up * bounce_dir * bounce_strength);
        // }
    }

    void OnValidate() {
        Debug.Assert(speed > 0f);
        Debug.Assert(bounce_strength > 0f);
    }

    /*=============================================================================
    * Class Methods
    =============================================================================*/
}
