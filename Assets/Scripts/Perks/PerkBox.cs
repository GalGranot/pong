using UnityEngine;
public class PerkBox : MonoBehaviour {
    [SerializeField] float fall_speed;
    [SerializeField] Rigidbody2D rb;

    void FixedUpdate() {
        Vector2 new_position = rb.position + fall_speed * Time.fixedDeltaTime * Vector2.down;
        rb.position = new_position;
    }
}