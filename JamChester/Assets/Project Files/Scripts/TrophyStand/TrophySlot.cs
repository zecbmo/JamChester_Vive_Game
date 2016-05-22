using UnityEngine;
using System.Collections;

public class TrophySlot : MonoBehaviour {
    
    public bool isUsed = false;

    public TrophyShelf owner;	

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
                }
                else
                {
                    //play sounds and loos one life
                }
            }
        }
    }
}
