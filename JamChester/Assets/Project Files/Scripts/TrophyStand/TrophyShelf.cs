using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class TrophyShelf : MonoBehaviour {
    public bool isCompleted;
    
    public TrophySlot[] slots;
    public TrophySlot slotPrefab;

    public Vector3 slotSpacing;   

    // Use this for initialization
    void Start () {
        for(int i = 0; i < slots.Length; i++) {
            
            slots[i] = Instantiate(slotPrefab, transform.position + slotSpacing*i,Quaternion.identity) as TrophySlot;
            slots[i].owner = gameObject.GetComponent<TrophyShelf>();
            slots[i].gameObject.SetActive(true);
        }
    }
    public void MoveShelf(Vector3 vector) {
        transform.position += vector;
        foreach (TrophySlot slot in slots)
        {
            slot.transform.Translate(vector);
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
            //Debug.Log("SlotFilled");
            isCompleted = true;
            WaveController.wave_complete = true;
        }

    }
}
