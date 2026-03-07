using TMPro;
using UnityEngine;

public class CountdownText : MonoBehaviour {
    TextMeshProUGUI text;
    
    void Start() {
        text = GetComponent<TextMeshProUGUI>();
        if(!text) throw new MissingComponentException();
        text.enabled = false;
    }

    void OnEnable() => GameManager.on_countdown_tick += UpdateText;
    void OnDisable() => GameManager.on_countdown_tick -= UpdateText;

    void UpdateText(string s) {
        text.enabled = true;
        text.text = s;
    }
}
