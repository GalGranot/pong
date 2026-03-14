using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Perks/Perk")]
public class Perk : ScriptableObject {
    [SerializeField] List<ScriptableObject> effects;
    
    public void Apply(PerkCtx ctx) {
        foreach(var asset in effects) {
            if(asset is not IPerkEffect _effect) {
                Debug.LogWarning("bad effect at Perk.cs");
            }
            var effect = (IPerkEffect)asset;
            effect.Apply(ctx);
        }
    }
}