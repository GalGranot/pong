using UnityEngine;

public abstract class Perk : ScriptableObject {
    public string label;
    public abstract void Apply(PerkCtx ctx);
}

