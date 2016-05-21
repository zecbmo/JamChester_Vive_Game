using UnityEngine;
using System.Collections;

public class NewItemSpawner : MonoBehaviour {

    public WaveNumber current_wave = WaveNumber.ONE;

    private bool item_spawned =  false;

    public bool tutorial_running = true;
    public float tutorial_time = 30;
    private float tutorial_count = 0;


    public GameObject[] wave_one_items;
    public TrophyType[] wave_one_types;
    public GameObject[] wave_two_items;
    public GameObject[] wave_three_items;
    public GameObject[] wave_four_items;
    public GameObject[] wave_five_items;
    public GameObject[] wave_six_items;
    public GameObject[] wave_seven_items;
    public GameObject[] wave_eight_items;
    public GameObject[] wave_nine_items;
    public GameObject[] wave_ten_items;
   

    // Use this for initialization
    void Start () {
	
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

    void SpawnBasedOnWave()
    {
        switch (current_wave)
        {
            case WaveNumber.ONE:
                SpawnArrayItems(wave_one_items);
                break;
            case WaveNumber.TWO:
                SpawnArrayItems(wave_two_items);
                break;
            case WaveNumber.THREE:
                SpawnArrayItems(wave_three_items);
                break;
            case WaveNumber.FOUR:
                SpawnArrayItems(wave_four_items);
                break;
            case WaveNumber.FIVE:
                SpawnArrayItems(wave_five_items);
                break;
            case WaveNumber.SIX:
                SpawnArrayItems(wave_six_items);
                break;
            case WaveNumber.SEVEN:
                SpawnArrayItems(wave_seven_items);
                break;
            case WaveNumber.EIGHT:
                SpawnArrayItems(wave_eight_items);
                break;
            case WaveNumber.NINE:
                SpawnArrayItems(wave_nine_items);
                break;
            case WaveNumber.TEN:
                SpawnArrayItems(wave_ten_items);
                break;

        }
    }

    void SpawnArrayItems(GameObject[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Instantiate(items[i], transform.position, Quaternion.identity);
        }
    }

   
}
