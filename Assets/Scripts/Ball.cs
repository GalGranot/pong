using System;
using UnityEngine;
public class Ball : MonoBehaviour {

    /*=============================================================================
    * Class Variables
    =============================================================================*/
    [SerializeField] Rigidbody2D rb;
    GameManager gm;

    public static Action<int> on_ball_paddle_collision;

    /*=============================================================================
    * Unity Callbacks 
    =============================================================================*/
    void Start() {
        //! FIXME: make this random/related to game
        gm = GameManager.Instance;
        rb.linearVelocity = new Vector2(5, 6);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        var other = collision.gameObject;
        if (other.CompareTag("BorderWalls")) {
            FlipHorzSpeed();
        }
        else if (other.CompareTag("RightWall")) {
            FlipVertSpeed();
        }
        else if (other.CompareTag("Paddle")) {
            PaddleHit(collision.gameObject.transform.position.y);
            on_ball_paddle_collision?.Invoke(1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("DeadZone")) {
            gm.MoveToGameOver();
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
        v.y = Mathf.Sign(v.x) * -1 * magnitude;
        v.x += offset;
        rb.linearVelocity = v;
    }

}
