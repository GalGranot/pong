using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class PaddleCtrlr : MonoBehaviour {
    public float speed;
    public GameManager gm;
    public Key down_key;
    public Key up_key;
    public Rigidbody2D rb;
    float move;
    
    void Start() {
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnValidate() {
        Debug.Assert(speed > 0f);       
    }

    void Update() {
        var y = transform.position.y;
        move = 0f;
        if(Keyboard.current[up_key].isPressed && y < gm.upper_vertical_border) move += 1f;
        if(Keyboard.current[down_key].isPressed && y > -gm.upper_vertical_border) move -= 1f;
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + Vector2.up * speed * move * Time.fixedDeltaTime);
    }
}