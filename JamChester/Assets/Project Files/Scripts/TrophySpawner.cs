using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TrophySpawner : MonoBehaviour {

    public TrophyShelfSpawner shelfSpawner;
    public GenericTrophy[] spawnableTrophies;
    public NewItemSpawner newItemSpawnerRef;

    public float initialSpawnTime=1;
    public float spawnTimeDecrementAmount = 0;
    public int numberOfTicksForReduction = 0;

    int spawnedTrophies = 0;
    [SerializeField]
    List<TrophyType> availableType = new List<TrophyType>();

    float timer = 0;
    int reductionTickCount = 0;

    public void AddType(TrophyType type) {
        availableType.Add(type);
    }
    public void IncrementTrophiesCount() {
        spawnedTrophies++;
    }
	
	// Update is called once per frame
	void Update () {
        if(newItemSpawnerRef.tutorial_running) {
            return;
        }

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

        if (spawnedTrophies >= shelfSpawner.availableSlots)
        {
            //Debug.Log("slots" + shelfSpawner.availableSlots);
            //Debug.Log("trophies" + spawnedTrophies);
            shelfSpawner.SpawnNewRow();
        }

        bool success = false;
        int attempts = 0;
        int slotID = 0;
        while (!success) {
            slotID = Random.Range(0, spawnableTrophies.Length);
            foreach (TrophyType trophy_type in availableType) {
                if (spawnableTrophies[slotID].type == trophy_type) {
                    success = true;
                }
            }
            attempts++;
            if (attempts > 100) {
                //Debug.Log("failed to find valid object");
                return;
            }
        }
        GenericTrophy tempobject = Instantiate(spawnableTrophies[slotID],transform.position,Quaternion.identity) as GenericTrophy;
        tempobject.gameObject.SetActive(true);
        spawnedTrophies++;        
    }
}
