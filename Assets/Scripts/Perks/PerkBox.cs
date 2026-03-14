using UnityEngine;
public class PerkBox : MonoBehaviour {
    [SerializeField] float fall_speed;
    [SerializeField] Rigidbody2D rb;
    Perk perk;

    void Start() {
        rb.linearVelocity = Vector2.down * fall_speed;
    }

    public void Init(Perk perk_) => perk = perk_;

    void OnTriggerEnter2D(Collider2D collision) {
        var other = collision.gameObject;
        if(other.CompareTag("Paddle")) {
            var ctx = new PerkCtx(other.GetComponent<Paddle>());
            perk.Apply(ctx);
            Destroy(gameObject);
        }
        else if(other.CompareTag("DeadZone")) {
            Destroy(gameObject);
        }
    }
}