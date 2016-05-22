using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TrophySpawner : MonoBehaviour {

    public TrophyShelfSpawner shelfSpawner;
    public List<GenericTrophy> spawnableTrophies;
    public NewItemSpawner newItemSpawnerRef;

    public float initialSpawnTime=1;
    public float spawnTimeDecrementAmount = 0;
    public int numberOfTicksForReduction = 0;


    int availableRange = 0;

    public int spawnedTrophies = 0;    

    float timer = 0;
    int reductionTickCount = 0;

    GameObject SoundManager;
    Sound sound_manager;
    public void RemoveItemAt(int count)
    {
        spawnableTrophies.RemoveAt(count);       
    }
    public void IncreaseRandomRange(int count) {
        availableRange += count;
    }
    public void IncreaseTrophies(int count) {
        spawnedTrophies+=count;
    }

    void Start() {
        SoundManager = GameObject.FindGameObjectWithTag("SOUND");
        sound_manager = SoundManager.GetComponent<Sound>();
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

        if (spawnedTrophies > shelfSpawner.availableSlots)
        {
            shelfSpawner.SpawnNewRow();
        }
        if(availableRange == 0)
        {
            return;
        }
        int slotID = Random.Range(0, availableRange);        
        float random_z = transform.position.z - Random.Range(-0.2f, 0.2f);
        Vector3 spawn_point = new Vector3(transform.position.x, transform.position.y, random_z);
        GenericTrophy tempobject = Instantiate(spawnableTrophies[slotID], spawn_point, Quaternion.identity) as GenericTrophy;
        tempobject.gameObject.SetActive(true);
        sound_manager.PlaySFX(Sound.SFX.SPAWNSOUND);
        spawnedTrophies++;        
    }
}
