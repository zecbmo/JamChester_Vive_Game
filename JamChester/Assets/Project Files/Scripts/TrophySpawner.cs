using UnityEngine;
using System.Collections;

public class TrophySpawner : MonoBehaviour {
    public GenericTrophy[] spawnableTrophies;    
    public float initialSpawnTime=1;
    public float spawnTimeDecrementAmount = 0;
    public int numberOfTicksForReduction = 0;

    float timer = 0;
    int reductionTickCount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (timer > initialSpawnTime) {
            SpawnTrophy();
            timer = 0;
            if (reductionTickCount > numberOfTicksForReduction) {
                reductionTickCount = 0;
                initialSpawnTime -= spawnTimeDecrementAmount;
                if (initialSpawnTime < 0) {
                    initialSpawnTime = 0;
                }
            }
        }
    }

    void SpawnTrophy() {
        Instantiate(spawnableTrophies[Random.Range(0, spawnableTrophies.Length)],transform.position,Quaternion.identity);        
    }
}
