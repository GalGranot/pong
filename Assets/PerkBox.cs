/*=============================================================================
* Includes
=============================================================================*/
using UnityEngine;
public class PerkBox : MonoBehaviour {
    /*=============================================================================
    * Class Variables
    =============================================================================*/
    [SerializeField] Perk perk;
    Rigidbody2D rb;
    [SerializeField] float falldown_speed = -5f;

    /*=============================================================================
    * Unity Callbacks 
    =============================================================================*/
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0, falldown_speed);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Paddle")) {
            perk.Apply(collision.gameObject.GetComponent<PaddleCtrlr>());
            Destroy(gameObject);
        }
    }

    /*=============================================================================
    * Class Methods
    =============================================================================*/

}