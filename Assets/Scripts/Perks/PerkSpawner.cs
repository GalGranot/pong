using System.Collections;
using UnityEngine;
public class PerkSpawner : MonoBehaviour {
    [SerializeField]  GameObject perkbox_prefab;
    [SerializeField] int spawn_rate_secs;
    [SerializeField] float y_spawn;

    void Start() {
        StartCoroutine(Spawn());
    }

    Vector2 SpawnPosition() {
        float x_spawn = Random.Range(-Config.x_bound, Config.x_bound);
        return new Vector2(x_spawn, y_spawn);
    }

    IEnumerator Spawn() {
        while(true) {
            print("Spawning perk");
            yield return new WaitForSeconds(spawn_rate_secs);
            Instantiate(perkbox_prefab, SpawnPosition(), Quaternion.identity);
        }
    }
}