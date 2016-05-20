using UnityEngine;
using System.Collections;

public enum TrophyType {
    T1,
    T2,
    T3,
    T4,
    T5,
    T6,
    T7,
    T8,
    T9,
    T10
}
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
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collision collision) {
        Trophy trophy = collision.gameObject.GetComponent<Trophy>();
        if (trophy == null) {
            return;
        }
        if (trophy.type == trophyType&& trophy.isClean) {
            isUsed = true;            
        }
    }
}
