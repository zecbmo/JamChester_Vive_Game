using UnityEngine;
using System.Collections;


public class NewItemSpawner : MonoBehaviour {
    public TrophySpawner trophySpawnerRef;

    public WaveNumber current_wave = WaveNumber.ONE;

    private bool item_spawned =  false;

    public bool tutorial_running = true;
    public float tutorial_time = 10;
    private float tutorial_count = 0;

    public GameObject[] waveOneitems;
    public int removeItemCountOne;
    public int itemRangeIncreaseOne;
    public int spawnedTrophiesCountOne;

    public GameObject[] waveTwoitems;
    public int removeItemCountTwo;
    public int itemRangeIncreaseTwo;
    public int spawnedTrophiesCountTwo;

    public GameObject[] waveThreeitems;
    public int removeItemCountThree;
    public int itemRangeIncreaseThree;
    public int spawnedTrophiesCountThree;

    public GameObject[] waveFouritems;
    public int removeItemCountFour;
    public int itemRangeIncreaseFour;
    public int spawnedTrophiesCountFour;

    public GameObject[] waveFiveitems;
    public int removeItemCountFive;
    public int itemRangeIncreaseFive;
    public int spawnedTrophiesCountFive;

    public GameObject[] waveSixitems;
    public int removeItemCountSix;
    public int itemRangeIncreaseSix;
    public int spawnedTrophiesCountSix;

    public GameObject[] waveSevenitems;
    public int removeItemCountSeven;
    public int itemRangeIncreaseSeven;
    public int spawnedTrophiesCountSeven;

    public GameObject[] waveEightitems;
    public int removeItemCountEight;
    public int itemRangeIncreaseEight;
    public int spawnedTrophiesCountEight;

    public GameObject[] waveNineitems;
    public int removeItemCountNine;
    public int itemRangeIncreaseNine;
    public int spawnedTrophiesCountNine;

    public GameObject[] waveTenitems;
    public int removeItemCountTen;
    public int itemRangeIncreaseTen;
    public int spawnedTrophiesCountTen;

    public GameObject[] waveElevenitems;
    public int removeItemCountEleven;
    public int itemRangeIncreaseEleven;
    public int spawnedTrophiesCountEleven;

    public GameObject[] waveTwelveitems;
    public int removeItemCountTwelve;
    public int itemRangeIncreaseTwelve;
    public int spawnedTrophiesCountTwelve;

    public GameObject[] waveThirteenitems;
    public int removeItemCountThirteen;
    public int itemRangeIncreaseThirteen;
    public int spawnedTrophiesCountThirteen;

    public GameObject[] waveFourteenitems;
    public int removeItemCountFourteen;
    public int itemRangeIncreaseFourteen;
    public int spawnedTrophiesCountFourteen;

    public GameObject[] waveFifteenitems;
    public int removeItemCountFifteen;
    public int itemRangeIncreaseFifteen;
    public int spawnedTrophiesCountFifteen;

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
    
    void SpawnBasedOnWave()
    {
        switch (current_wave)
        {
            case WaveNumber.ONE:
                SpawnArrayItems(waveOneitems, removeItemCountOne, itemRangeIncreaseOne, spawnedTrophiesCountOne);               
                break;
            case WaveNumber.TWO:
                SpawnArrayItems(waveTwoitems, removeItemCountTwo, itemRangeIncreaseTwo, spawnedTrophiesCountTwo);
                break;
            case WaveNumber.THREE:
                SpawnArrayItems(waveThreeitems, removeItemCountThree, itemRangeIncreaseThree, spawnedTrophiesCountThree);
                break;
            case WaveNumber.FOUR:
                SpawnArrayItems(waveFouritems, removeItemCountFour, itemRangeIncreaseFour, spawnedTrophiesCountFour);
                break;
            case WaveNumber.FIVE:
                SpawnArrayItems(waveFiveitems, removeItemCountFive, itemRangeIncreaseFive, spawnedTrophiesCountFive);
                break;
            case WaveNumber.SIX:
                SpawnArrayItems(waveSixitems, removeItemCountSix, itemRangeIncreaseSix, spawnedTrophiesCountSix);
                break;
            case WaveNumber.SEVEN:
                SpawnArrayItems(waveSevenitems, removeItemCountSeven, itemRangeIncreaseSeven, spawnedTrophiesCountSeven);
                break;
            case WaveNumber.EIGHT:
                SpawnArrayItems(waveEightitems, removeItemCountEight, itemRangeIncreaseEight, spawnedTrophiesCountEight);
                break;
            case WaveNumber.NINE:
                SpawnArrayItems(waveNineitems, removeItemCountNine, itemRangeIncreaseNine, spawnedTrophiesCountNine);
                break;
            case WaveNumber.TEN:
                SpawnArrayItems(waveEightitems, removeItemCountEight, itemRangeIncreaseEight, spawnedTrophiesCountEight);
                break;
            case WaveNumber.ELEVEN:
                SpawnArrayItems(waveElevenitems, removeItemCountEleven, itemRangeIncreaseEleven, spawnedTrophiesCountEleven);
                break;
            case WaveNumber.TWELVE:
                SpawnArrayItems(waveTwelveitems, removeItemCountTwelve, itemRangeIncreaseTwelve, spawnedTrophiesCountTwelve);
                break;
            case WaveNumber.THIRTEEN:
                SpawnArrayItems(waveThirteenitems, removeItemCountThirteen, itemRangeIncreaseThirteen, spawnedTrophiesCountThirteen);
                break;
            case WaveNumber.FOURTEEN:
                SpawnArrayItems(waveFourteenitems, removeItemCountFourteen, itemRangeIncreaseFourteen, spawnedTrophiesCountFourteen);
                break;
            case WaveNumber.FIFTEEN:
                SpawnArrayItems(waveFifteenitems, removeItemCountFifteen, itemRangeIncreaseFifteen, spawnedTrophiesCountFifteen);
                break;
        }
    }

    void SpawnArrayItems(GameObject[] items, int removeItemCount, int itemRangeIncrease, int spawnedTrophiesCount)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Instantiate(items[i], transform.position, Quaternion.identity);
        }
        sound_manager.PlaySFX(Sound.SFX.SPAWNSOUND);

        trophySpawnerRef.RemoveItemsFromFront(removeItemCount);
        trophySpawnerRef.IncreaseRandomRange(itemRangeIncrease);
        trophySpawnerRef.IncreaseTrophies(spawnedTrophiesCount);
    }

   
}
