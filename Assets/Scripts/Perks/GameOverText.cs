using TMPro;
using UnityEngine;
public class GameOverText : MonoBehaviour {
    static string[] text_options = {
        "Impressive. Truly. If the goal was losing.",
        "Maybe the ball just isn't your thing.",
        "Have you tried… hitting it back?",
        "That was a bold strategy. Not a good one, but bold.",
        "The ball thanks you for your continued cooperation.",
        "You almost had it. By almost I mean not at all.",
        "Great effort. The wall would've done better though.",
        "At this point the paddle is just decorative.",
        "Don't worry. Nobody saw that. Except the score.",
        "You're really consistent. Consistently losing.",
        "Maybe Pong just isn't your sport.",
        "The ball moved three times and you gave up.",
        "Have you considered watching instead of playing?",
        "Somewhere a 1972 arcade cabinet is disappointed.",
        "You were defeated by a rectangle.",
        "Don't feel bad. The AI practiced all week.",
        "Technically that counted as playing.",
        "Progress update: still bad.",
        "Good news: it can't get worse. Probably.",
        "Press restart and pretend that never happened.",
    };

    string RandomText() {
        return text_options[Random.Range(0, text_options.Length)];
    }

    void Start() {
        var text = GetComponent<TextMeshProUGUI>();
        text.text = RandomText();
    }
}