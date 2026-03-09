using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class UpScorePerk : Perk {
    [SerializeField] int up_score_amount;


#if UNITY_EDITOR
    void OnValidate() {
        if(up_score_amount <= 0) {
            Debug.LogError($"{nameof(up_score_amount)} must be positive", this);
        }
    }
#endif

    public override void Apply(PerkCtx _ctx) {
        GameManager.Instance.UpdateScore(up_score_amount);
    }
}