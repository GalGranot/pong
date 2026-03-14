using UnityEngine;

[CreateAssetMenu(menuName = "Perks/Effects/Speed")]
public class SpeedEffect : ScriptableObject, IPerkEffect {
    public float bonus = 3f;
    public void Apply(PerkCtx ctx) => ctx.paddle.AddSpeed(bonus);
}
