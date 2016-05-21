using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TrophySpawner : MonoBehaviour {

    public GenericTrophy[] spawnableTrophies;    

    public float initialSpawnTime=1;
    public float spawnTimeDecrementAmount = 0;
    public int numberOfTicksForReduction = 0;

    public List<TrophyType> availableType;
    float timer = 0;
    int reductionTickCount = 0;

    void AddType(TrophyType type) {
        availableType.Add(type);
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
