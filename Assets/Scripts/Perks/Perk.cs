using UnityEngine;

public abstract class Perk : ScriptableObject {
    public abstract void Apply(PaddleCtrlr paddle);
}

