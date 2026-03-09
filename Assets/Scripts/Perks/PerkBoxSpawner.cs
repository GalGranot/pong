/*=============================================================================
* Includes
=============================================================================*/
using System.Collections;
using UnityEngine;
public class PerkBoxSpawner : MonoBehaviour {
    /*=============================================================================
    * Class Variables
    =============================================================================*/
    [SerializeField] PerkBox prefab;
    [SerializeField] Perk[] perks_list;
    [SerializeField] int perk_spawn_rate_seconds;
    [SerializeField] float perk_spawn_y;
    [SerializeField] float perk_spawn_x_min;
    [SerializeField] float perk_spawn_x_max;

    /*=============================================================================
    * Unity Callbacks 
    =============================================================================*/
    void Start() {
        StartCoroutine(SpawnPerks(perk_spawn_rate_seconds));
    }

    /*=============================================================================
    * Class Methods
    =============================================================================*/
    public void SpawnAt(Vector2 pos) {
        var box = Instantiate(prefab, pos, Quaternion.identity);
        var perk = perks_list[Random.Range(0, perks_list.Length)];
        box.Init(perk);
    }

    IEnumerator SpawnPerks(int spawn_rate_seconds) {
        while(true) {
            yield return new WaitForSeconds(spawn_rate_seconds);
            var pos = new Vector2(
                Random.Range(perk_spawn_x_min, perk_spawn_x_max),
                perk_spawn_y
            );
            SpawnAt(pos);
        }
    }

}