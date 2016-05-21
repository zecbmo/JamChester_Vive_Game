using UnityEngine;
using System.Collections;

public class TrophySlot : MonoBehaviour {
    
    public bool isUsed = false;

    public TrophyShelf owner;	

    void OnTriggerEnter(Collider collider) {
        if (!isUsed) {
            GenericTrophy trophy = collider.gameObject.GetComponent<GenericTrophy>();

            if (trophy == null) {
                //Debug.Log("Trophy Slot collider null?");
                return;
            }
            if (trophy.IsCompleted()&& trophy.isGrabbable) {
                isUsed = true;
                trophy.isGrabbable = false;

               // Debug.Log("Triggered Trophy Slot");
                if (owner) {
                    owner.OnSlotFilled();
                }
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<TrophySlot>().enabled = false;
                collider.gameObject.transform.parent = gameObject.transform;
                
            }
        }
    }
}
