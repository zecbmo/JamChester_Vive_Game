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
    public int[] removeItemCountOne;
    public int itemRangeIncreaseOne;
   
    public GameObject[] waveTwoitems;
    public int[] removeItemCountTwo;
    public int itemRangeIncreaseTwo;

    public GameObject[] waveThreeitems;
    public int[] removeItemCountThree;
    public int itemRangeIncreaseThree;

    public GameObject[] waveFouritems;
    public int[] removeItemCountFour;
    public int itemRangeIncreaseFour;

    public GameObject[] waveFiveitems;
    public int[] removeItemCountFive;
    public int itemRangeIncreaseFive;

    public GameObject[] waveSixitems;
    public int[] removeItemCountSix;
    public int itemRangeIncreaseSix;

    public GameObject[] waveSevenitems;
    public int[] removeItemCountSeven;
    public int itemRangeIncreaseSeven;

    public GameObject[] waveEightitems;
    public int[] removeItemCountEight;
    public int itemRangeIncreaseEight;

    public GameObject[] waveNineitems;
    public int[] removeItemCountNine;
    public int itemRangeIncreaseNine;

    public GameObject[] waveTenitems;
    public int[] removeItemCountTen;
    public int itemRangeIncreaseTen;

    public GameObject[] waveElevenitems;
    public int[] removeItemCountEleven;
    public int itemRangeIncreaseEleven;

    public GameObject[] waveTwelveitems;
    public int[] removeItemCountTwelve;
    public int itemRangeIncreaseTwelve;

    public GameObject[] waveThirteenitems;
    public int[] removeItemCountThirteen;
    public int itemRangeIncreaseThirteen;

    public GameObject[] waveFourteenitems;
    public int[] removeItemCountFourteen;
    public int itemRangeIncreaseFourteen;

    public GameObject[] waveFifteenitems;
    public int[] removeItemCountFifteen;
    public int itemRangeIncreaseFifteen;

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

        //trophySpawnerRef.spawnedTrophies
        
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
                SpawnArrayItems(waveOneitems, removeItemCountOne, itemRangeIncreaseOne);               
                break;
            case WaveNumber.TWO:
                SpawnArrayItems(waveTwoitems, removeItemCountTwo, itemRangeIncreaseTwo);
                break;
            case WaveNumber.THREE:
                SpawnArrayItems(waveThreeitems, removeItemCountThree, itemRangeIncreaseThree);
                break;
            case WaveNumber.FOUR:
                SpawnArrayItems(waveFouritems, removeItemCountFour, itemRangeIncreaseFour);
                break;
            case WaveNumber.FIVE:
                SpawnArrayItems(waveFiveitems, removeItemCountFive, itemRangeIncreaseFive);
                break;
            case WaveNumber.SIX:
                SpawnArrayItems(waveSixitems, removeItemCountSix, itemRangeIncreaseSix);
                break;
            case WaveNumber.SEVEN:
                SpawnArrayItems(waveSevenitems, removeItemCountSeven, itemRangeIncreaseSeven);
                break;
            case WaveNumber.EIGHT:
                SpawnArrayItems(waveEightitems, removeItemCountEight, itemRangeIncreaseEight);
                break;
            case WaveNumber.NINE:
                SpawnArrayItems(waveNineitems, removeItemCountNine, itemRangeIncreaseNine);
                break;
            case WaveNumber.TEN:
                SpawnArrayItems(waveEightitems, removeItemCountEight, itemRangeIncreaseEight);
                break;
            case WaveNumber.ELEVEN:
                SpawnArrayItems(waveElevenitems, removeItemCountEleven, itemRangeIncreaseEleven);
                break;
            case WaveNumber.TWELVE:
                SpawnArrayItems(waveTwelveitems, removeItemCountTwelve, itemRangeIncreaseTwelve);
                break;
            case WaveNumber.THIRTEEN:
                SpawnArrayItems(waveThirteenitems, removeItemCountThirteen, itemRangeIncreaseThirteen);
                break;
            case WaveNumber.FOURTEEN:
                SpawnArrayItems(waveFourteenitems, removeItemCountFourteen, itemRangeIncreaseFourteen);
                break;
            case WaveNumber.FIFTEEN:
                SpawnArrayItems(waveFifteenitems, removeItemCountFifteen, itemRangeIncreaseFifteen);
                break;
        }
    }

    void SpawnArrayItems(GameObject[] items, int[] removeItemCount, int itemRangeIncrease)
    {
        for (int i = 0; i < items.Length; i++)
        {
            GameObject temp = Instantiate(items[i], transform.position, Quaternion.identity)as GameObject;
            temp.SetActive(true);
        }
        sound_manager.PlaySFX(Sound.SFX.SPAWNSOUND);
        for (int i = 0; i < removeItemCount.Length; i++)
        {
            trophySpawnerRef.RemoveItemAt(removeItemCount[i]);
            itemRangeIncrease--;
        }
        
        trophySpawnerRef.IncreaseRandomRange(itemRangeIncrease);
    }

   
}
