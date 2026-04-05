using UnityEngine;
public class Resettable : MonoBehaviour {
    Rigidbody2D rb;
    Vector2 initial_position;
    public RigidbodyConstraints2D constraints;

    [SerializeField] float init_vx;
    [SerializeField] float init_vy;
    [SerializeField] bool has_initial_velocity;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        initial_position = transform.position;
    }

    public void freeze() => rb.constraints = RigidbodyConstraints2D.FreezeAll;

    public void reset_to_start() {
        rb.constraints = constraints;
        rb.position = initial_position;
        if (has_initial_velocity) {
            rb.linearVelocity = new Vector2(init_vx, init_vy);
        }
    }
}
