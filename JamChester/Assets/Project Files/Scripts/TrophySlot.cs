using UnityEngine;
using System.Collections;

public class TrophySlot : MonoBehaviour {
    [Header("Trophy Rules")]
    public TrophyType trophyType = TrophyType.NONE;
    public TrophyType invalidLeft = TrophyType.NONE;
    public TrophyType invalidRight = TrophyType.NONE;
    public bool isUsed = false;

    public TrophyShelf owner;
	

    void OnTriggerEnter(Collider collision) {
        GenericTrophy trophy = collision.gameObject.GetComponent<GenericTrophy>();

        if (trophy == null) {
            Debug.Log("Trophy Slot collider null?");
            return;
        }
        if (trophy.type == trophyType&& trophy.IsCompleted()) {

            isUsed = true;
            Debug.Log("Triggered Trophy Slot");
            if (owner) {
                owner.OnSlotFilled();
            }
            
        }
    }
}
