using UnityEngine;
using System.Collections;

class Trophy {
    public TrophyType type;
    public bool isClean;

}

public class TrophySlot : MonoBehaviour {
    public TrophyType trophyType;
    public TrophyType invalidLeft;
    public TrophyType invalidRight;
    private bool isUsed;

	// Use this for initialization
	void Start () {
        isUsed = false;
    }
	
    void OnTriggerEnter(Collision collision) {
        GenericTrophy trophy = collision.gameObject.GetComponent<GenericTrophy>();
        if (trophy == null) {
            return;
        }
        if (trophy.type == trophyType&& trophy.isClean) {
            isUsed = true;            
        }
    }
}
