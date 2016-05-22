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
    

    void OnTriggerStay(Collider collider) {
        if (!isUsed && collider.tag == "TROPHY") {
            GenericTrophy trophy = collider.gameObject.GetComponent<GenericTrophy>();            
            if (trophy == null) {
                return;
            }
            if (!trophy.IsGrabbed()&& !trophy.isUsed) {
                isUsed = true;
                trophy.isUsed = true;
                trophy.isGrabbable = false;

                if (owner) {
                    owner.OnSlotFilled();
                }
                collider.transform.rotation = Quaternion.identity;
                collider.transform.position = transform.position;
                transform.gameObject.SetActive(false);

                if (trophy.IsCompleted())
                {
                    //play sounds
                    sound_manager.PlaySFX(Sound.SFX.COMPLETED_GOOD);
                }
                else {
                    sound_manager.PlaySFX(Sound.SFX.COMPLETED_BAD);
                    //play sounds and loos one life
                }

            }
        }
    }
}
