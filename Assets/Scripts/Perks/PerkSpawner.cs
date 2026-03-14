using System.Collections;
using UnityEngine;
public class PerkSpawner : MonoBehaviour {
    [SerializeField]  GameObject perkbox_prefab;
    [SerializeField] float spawn_rate_secs;
    [SerializeField] float y_spawn;
    [SerializeField] Perk[] perk_pool;

    void Start() => StartCoroutine(Spawn());

    Perk RandomPerk() {
        return perk_pool[Random.Range(0, perk_pool.Length)];
    }
    

    Vector2 SpawnPosition() {
        float x_spawn = Random.Range(-Config.x_bound, Config.x_bound);
        return new Vector2(x_spawn, y_spawn);
    }

    IEnumerator Spawn() {
        while(true) {
            print("Spawning perk");
            yield return new WaitForSeconds(spawn_rate_secs);
            var box = Instantiate(perkbox_prefab, SpawnPosition(), Quaternion.identity);
            box
                .GetComponent<PerkBox>()
                .Init(RandomPerk());
            Debug.LogWarning("need to set up perk initialization here");
        }
    }
}