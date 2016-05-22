using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    // Use this for initialization
    public enum SFX { BRUSH, STAMP, CLOTH,  SPRAY, SPAWNSOUND, COMPLETED_GOOD, COMPLETED_BAD, DRINKING, GAME_OVER, TROPHY_ON_FLOOR, SPONGE};
    public  AudioClip[] soundlist;
    public  AudioSource source;

    void Start() {
        source = GetComponent<AudioSource>();
    }

    public void PlaySFX(SFX sfx) 
    {
        source.PlayOneShot(soundlist[(int)sfx]);      
           
    }

}
