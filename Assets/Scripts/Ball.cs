using UnityEngine;
public class Ball : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float init_x_speed;
    [SerializeField] float init_y_speed;

    void Start() {
        rb.linearVelocity = new Vector2(init_x_speed, init_y_speed);
    }

    void OnValidate() {
        if (init_x_speed <= 0f || init_y_speed <= 0f) Debug.LogError("initial ball speeds must be > 0");
    }
}
