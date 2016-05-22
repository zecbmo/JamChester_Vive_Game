using UnityEngine;
using System.Collections;

public class TrophySlot : MonoBehaviour {
    
    public bool isUsed = false;

    public TrophyShelf owner;
    GameObject SoundManager;
    Sound sound_manager;


    void Start() {
        SoundManager = GameObject.FindGameObjectWithTag("SOUND");
        sound_manager = SoundManager.GetComponent<Sound>();
    }
    

    void OnTriggerEnter(Collider collider) {
        if (!isUsed) {
            GenericTrophy trophy = collider.gameObject.GetComponent<GenericTrophy>();

            if (trophy == null) {
                //Debug.Log("Trophy Slot collider null?");
                return;
            }
            if (trophy.IsCompleted()) {
                isUsed = true;
                trophy.isGrabbable = false;

                // Debug.Log("Triggered Trophy Slot");
                if (owner) {
                    owner.OnSlotFilled();
                }
                collider.gameObject.transform.parent = gameObject.transform;
                collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.SetActive(false);
                sound_manager.PlaySFX(Sound.SFX.COMPLETED_GOOD);
            }
            else {
                sound_manager.PlaySFX(Sound.SFX.COMPLETED_BAD);
            }
        }
    }
}
