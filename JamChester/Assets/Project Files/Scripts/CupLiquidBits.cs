using UnityEngine;
using System.Collections;

public class CupLiquidBits : MonoBehaviour {

    // Use this for initialization
    private GameObject parent_trophy;
    GameObject SoundManager;
    Sound sound_manager;

    void Start() {
        SoundManager = GameObject.FindGameObjectWithTag("SOUND");
        sound_manager = SoundManager.GetComponent<Sound>();
    }

    public void SetParent(GameObject parent)
    {
        parent_trophy = parent;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "HEAD")
        {
            CupTrophy ct = parent_trophy.GetComponent<CupTrophy>();
            ct.drank = true;
            sound_manager.PlaySFX(Sound.SFX.DRINKING);

        }
    }
}
