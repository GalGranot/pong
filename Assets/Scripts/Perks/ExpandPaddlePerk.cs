using UnityEngine;

[CreateAssetMenu]
public class ExpandPaddlePerk : Perk {
    [SerializeField] float expand_amount;


#if UNITY_EDITOR
    void OnValidate() {
        if(expand_amount <= 0) {
            Debug.LogError($"{nameof(expand_amount)} must be positive", this);
        }
    }
#endif

    public override void Apply(PaddleCtrlr paddle) {
        paddle.Expand(expand_amount);
    }
}