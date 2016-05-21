using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class TrophyShelf : MonoBehaviour {
    public bool isCompleted;

    public List<TrophyType> availableType;

    public TrophySlot[] possibleSlots;

    public TrophySlot[] slots;

    public Vector3 slotSpacing;

    public void AddType(TrophyType type) {
        availableType.Add(type);
    }

    // Use this for initialization
    void Start () {
        for(int i = 0; i < slots.Length; i++) {
            bool success = false;
            int attempts = 0;
            int slotID = 0;
            while (!success) {
                slotID = Random.Range(0, possibleSlots.Length);
                foreach (TrophyType trophy_type in availableType) {
                    if (possibleSlots[slotID].trophyType == trophy_type) {
                        success = true;
                    }
                }
                attempts++;
                if (attempts > 100) {
                    return;
                }
            }
            slots[i] = Instantiate(possibleSlots[slotID], transform.position + slotSpacing*i,Quaternion.identity) as TrophySlot;
            slots[i].owner = gameObject.GetComponent<TrophyShelf>();
            slots[i].gameObject.SetActive(true);
        }
    }
    public void MoveShelf(Vector3 vector) {
        transform.position += vector;
        foreach (TrophySlot slot in slots)
        {
            slot.transform.position += vector;
        }
    }
    
    public void Update() {

    }

    public void OnSlotFilled() {
        // check if all slots are filled
        int num = 0;
        foreach (TrophySlot slot in slots) {
            if (slot.isUsed) {
                num++;
            }
        }
        print(num);
        if(num >= slots.Length) {
            Debug.Log("SlotFilled");
            isCompleted = true;
            WaveController.wave_complete = true;
        }

    }
}
