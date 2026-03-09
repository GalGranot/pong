/*=============================================================================
* Includes
=============================================================================*/
using TMPro;
using UnityEngine;
public class PerkBox : MonoBehaviour {
    /*=============================================================================
    * Class Variables
    =============================================================================*/
    [SerializeField] Perk perk;
    Rigidbody2D rb;
    [SerializeField] float falldown_speed = -5f;

    TextMeshProUGUI text;

    /*=============================================================================
    * Unity Callbacks 
    =============================================================================*/
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0, falldown_speed);
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = perk.label;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        var other = collision.gameObject;
        if(other.CompareTag("Paddle")) {
            PerkCtx ctx = new PerkCtx(other.GetComponent<PaddleCtrlr>());
            perk.Apply(ctx);
            Destroy(gameObject);
        } else if(other.CompareTag("DeadZone")) {
            Destroy(gameObject);
        }
    }

    /*=============================================================================
    * Class Methods
    =============================================================================*/
    public void Init(Perk given_perk) {
        perk = given_perk;
    }

}