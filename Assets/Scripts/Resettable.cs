using UnityEngine;
public class Resettable : MonoBehaviour {
    Rigidbody2D rb;
    Vector2 initial_position;
    public RigidbodyConstraints2D constraints;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        initial_position = transform.position;
    }

    public void freeze() => rb.constraints = RigidbodyConstraints2D.FreezeAll;

    public void reset_to_start() {
        rb.constraints = constraints;
        rb.position = initial_position;
    }
}
