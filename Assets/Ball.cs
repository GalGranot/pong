/*=============================================================================
* Includes
=============================================================================*/
using UnityEngine;
public class Ball : MonoBehaviour {

/*=============================================================================
* Class Variables
=============================================================================*/
public Rigidbody2D rb;
GameManager gm;

/*=============================================================================
* Unity Callbacks 
=============================================================================*/
void Awake() {
    
}

void Start() {
    //! FIXME: make this random/related to game
    gm = GameManager.Instance;
    rb.linearVelocity = new Vector2(5, 6);
}

void Update() {
    if(transform.position.x < gm.left_score_border) {
        gm.MoveToGameOver();
    }
}

void OnValidate() {

}

void OnCollisionEnter2D(Collision2D collision) {
    if(collision.gameObject.CompareTag("BorderWalls")) {
        FlipVertSpeed();
    } else if(collision.gameObject.CompareTag("RightWall")) {
        FlipHorzSpeed();
    } else if(collision.gameObject.CompareTag("Paddle")) {
        PaddleHit(collision.gameObject.transform.position.y);
        gm.UpdateScore();
    }
}

/*=============================================================================
* Class Methods
=============================================================================*/
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

void PaddleHit(float ypaddle) {
    float yball = transform.position.y;
    float offset = yball - ypaddle;
    //! FIXME: add division by paddle size here
    var v = rb.linearVelocity;
    float magnitude = Mathf.Sqrt(v.x * v.x + v.y * v.y);
    v.x = Mathf.Sign(v.x) * -1 * magnitude;
    v.y += offset;
    rb.linearVelocity = v;
}
}