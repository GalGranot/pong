// using UnityEngine;
// public class Ball : MonoBehaviour {
//     [SerializeField] float speed = 5f;
//     Rigidbody2D rb;
//     public GameManager gm;
//     public Collider2D col;
//     bool just_bounced = false;

//     void OnValidate() {
//         Debug.Assert(speed > 0f);
//     }

//     float MaybeNegativeOne() {
//         int rand_int = Random.Range(0, 2);
//         return rand_int == 0 ? -1f : 1f;
//     }

//     void Start() {
//         rb = GetComponent<Rigidbody2D>();
//         if(!rb) throw new MissingComponentException();
//         col = GetComponent<Collider2D>();
//         if(!GetComponent<Collider2D>()) throw new MissingComponentException();

//         float hor_speed_percent = Random.Range(0.5f, 1f);
//         rb.linearVelocity = new Vector2(
//             speed * hor_speed_percent * MaybeNegativeOne(),
//             speed * (1f - hor_speed_percent) * MaybeNegativeOne()
//         );

//     }

//     void FixedUpdate() {
//         var y = transform.position.y;
//         if(y >= gm.upper_vertical_border || y <= -gm.upper_vertical_border) {
//             var v = rb.linearVelocity;
//             v.y *= -Mathf.Abs(v.y) * (y > 0 ? -1f : 1f);
//             rb.linearVelocity = v;
//         }
//         just_bounced = false;
//     }

//     void OnCollisionEnter2D(Collision2D other) {
//         if (other.gameObject.CompareTag("Paddle")) {
//             if(just_bounced) return;
//             just_bounced = true;
//             Debug.Log("Hit paddle");

//             float y_paddle = other.transform.position.y;
//             float y_ball = transform.position.y;
//             float offset = y_ball - y_paddle;

//             Vector2 v = rb.linearVelocity;
//             v.x *= -1f;                       // flip X
//             v.y += offset * 0.5f;             // scale offset for reasonable bounce
//             rb.linearVelocity = v.normalized * speed; // maintain constant speed
//         }
//     }
// }

using System;
using UnityEditor.Callbacks;
using UnityEngine;
public class Ball : MonoBehaviour {

    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameManager gm;

    void Start() {
        //! FIXME something random
        rb.linearVelocity = new Vector2(
            5f,
            7f
        );   
    }

    void FixedUpdate() {
        var y = transform.position.y;
        if(y >= gm.upper_vertical_border || y <= -gm.upper_vertical_border) {
            var v = rb.linearVelocity;
            v.y *= -1;
            rb.linearVelocity = v;
        }
    }
}