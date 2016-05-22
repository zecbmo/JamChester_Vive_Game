using UnityEngine;
using System.Collections;

public class NewItemSpawner : MonoBehaviour {
    public TrophySpawner trophySpawnerRef;

    public WaveNumber current_wave = WaveNumber.ONE;

    private bool item_spawned =  false;

    public bool tutorial_running = true;
    public float tutorial_time = 10;
    private float tutorial_count = 0;
    
    public GameObject[] wave_one_items;
    public TrophyType[] wave_one_types;
    public GameObject[] wave_two_items;
    public TrophyType[] wave_two_types;
    public GameObject[] wave_three_items;
    public TrophyType[] wave_three_types;
    public GameObject[] wave_four_items;
    public TrophyType[] wave_four_types;
    public GameObject[] wave_five_items;
    public TrophyType[] wave_five_types;
    public GameObject[] wave_six_items;
    public TrophyType[] wave_six_types;
    public GameObject[] wave_seven_items;
    public TrophyType[] wave_seven_types;
    public GameObject[] wave_eight_items;
    public TrophyType[] wave_eight_types;
    public GameObject[] wave_nine_items;
    public TrophyType[] wave_nine_types;
    public GameObject[] wave_ten_items;
    public TrophyType[] wave_ten_types;

    GameObject SoundManager;
    Sound sound_manager;

    // Use this for initialization
    void Start () {
        SoundManager = GameObject.FindGameObjectWithTag("SOUND");
        sound_manager = SoundManager.GetComponent<Sound>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (WaveController.wave_complete)
        {
            WaveController.wave_complete = false;
            tutorial_running = true;
            SpawnBasedOnWave();
            current_wave++;
        }

        if (Input.GetKeyDown("space"))
        {
            WaveController.wave_complete = true;
        }
    }

    void FixedUpdate()
    {
        if (tutorial_running)
        {
            if (tutorial_count > tutorial_time)
            {
                tutorial_running = false;
                tutorial_count = 0;
            }

            tutorial_count += Time.deltaTime;
        }
    }
    void UnlockTypes(TrophyType[] trophy_types) {
        foreach(TrophyType type in trophy_types) {
            if(trophySpawnerRef)
            trophySpawnerRef.AddType(type);
        }
    }
    void SpawnBasedOnWave()
    {
        switch (current_wave)
        {
            case WaveNumber.ONE:
                SpawnArrayItems(wave_one_items);
                UnlockTypes(wave_one_types);
                trophySpawnerRef.IncrementTrophiesCount();
                break;
            case WaveNumber.TWO:
                SpawnArrayItems(wave_two_items);
                UnlockTypes(wave_two_types);
                trophySpawnerRef.IncrementTrophiesCount();
                break;
            case WaveNumber.THREE:
                SpawnArrayItems(wave_three_items);
                UnlockTypes(wave_three_types);
                trophySpawnerRef.IncrementTrophiesCount();
                break;
            case WaveNumber.FOUR:
                SpawnArrayItems(wave_four_items);
                UnlockTypes(wave_four_types);
                trophySpawnerRef.IncrementTrophiesCount();
                break;
            case WaveNumber.FIVE:
                SpawnArrayItems(wave_five_items);
                UnlockTypes(wave_five_types);
                trophySpawnerRef.IncrementTrophiesCount();
                break;
            case WaveNumber.SIX:
                SpawnArrayItems(wave_six_items);
                UnlockTypes(wave_six_types);
                trophySpawnerRef.IncrementTrophiesCount();
                break;
            case WaveNumber.SEVEN:
                SpawnArrayItems(wave_seven_items);
                UnlockTypes(wave_seven_types);
                trophySpawnerRef.IncrementTrophiesCount();
                break;
            case WaveNumber.EIGHT:
                SpawnArrayItems(wave_eight_items);
                UnlockTypes(wave_eight_types);
                trophySpawnerRef.IncrementTrophiesCount();
                break;
            case WaveNumber.NINE:
                SpawnArrayItems(wave_nine_items);
                UnlockTypes(wave_nine_types);
                trophySpawnerRef.IncrementTrophiesCount();
                break;
            case WaveNumber.TEN:
                SpawnArrayItems(wave_ten_items);
                UnlockTypes(wave_ten_types);
                trophySpawnerRef.IncrementTrophiesCount();
                break;

        }
    }

    void SpawnArrayItems(GameObject[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Instantiate(items[i], transform.position, Quaternion.identity);
        }
        sound_manager.PlaySFX(Sound.SFX.SPAWNSOUND);
    }

   
}
