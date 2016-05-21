using UnityEngine;
using System.Collections;


public class TrophyShelf : MonoBehaviour {
    public bool isCompleted;

    public TrophySlot[] possibleSlots;

    public TrophySlot[] slots;

    public Vector3 slotSpacing;

	// Use this for initialization
	void Start () {
        Random rnd = new Random();
        for(int i = 0; i < slots.Length; i++) {
            slots[i] = (TrophySlot)Instantiate(possibleSlots[0], transform.position + slotSpacing*i,Quaternion.identity);
        }
    }
    

    public void OnSlotFilled() {
        // check if all slots are filled
        int num = 0;
        foreach (TrophySlot slot in slots) {
            if (slot.isUsed) {
                num++;
            }
        }
        if(num > 4) {
            Debug.Log("SlotFilled");
            isCompleted = true;
        }

    }
}
