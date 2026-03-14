using UnityEngine;
public class PerkBox : MonoBehaviour {
    [SerializeField] float fall_speed;
    [SerializeField] Rigidbody2D rb;

    void FixedUpdate() {
        Vector2 new_position = rb.position + fall_speed * Time.fixedDeltaTime * Vector2.down;
        rb.position = new_position;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        var other = collision.gameObject;
        if(other.CompareTag("Paddle")) {
            print("perk - paddle");
        }
        else if(other.CompareTag("DeadZone")) {
            Destroy(gameObject);
        }
    }
}