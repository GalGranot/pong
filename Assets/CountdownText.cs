using TMPro;
using UnityEngine;

public class CountdownText : MonoBehaviour
{
    void Start() {
        GameManager
            .Instance
            .countdown_text = GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }
}
