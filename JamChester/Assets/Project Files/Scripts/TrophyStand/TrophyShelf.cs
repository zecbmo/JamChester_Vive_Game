using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class TrophyShelf : MonoBehaviour {
    public bool isCompleted;
    
    public TrophySlot[] slots;
    public TrophySlot slotPrefab;

    public Vector3 slotSpacing;

    float startTime;
    float journeyLength;
    Vector3 startPoint;
    Vector3 endPoint;
    public float speed = 1.0f;

    bool isMoving = false;

    // Use this for initialization
    public void CreateSlots () {
        for(int i = 0; i < slots.Length; i++) {            
            slots[i] = Instantiate(slotPrefab, slotPrefab.gameObject.transform.position + slotSpacing*i,Quaternion.identity) as TrophySlot;
            slots[i].owner = gameObject.GetComponent<TrophyShelf>();
            slots[i].gameObject.transform.parent = gameObject.transform;
            slots[i].gameObject.SetActive(true);
        }
    }
    public void MoveShelf(Vector3 vector) {
        startPoint = gameObject.transform.position;  

        startTime = Time.time;
        if (isMoving) {
            endPoint += vector;
        }
        else {
            endPoint = startPoint + vector;
        }
        journeyLength = Vector3.Distance(startPoint, endPoint);

        isMoving = true;
      
    }
    
    public void Update() {
        if (isMoving) {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPoint, endPoint, fracJourney);
            if (fracJourney > 1.0f) {
                isMoving = false;
            }
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
       // print(num);
        if(num >= slots.Length) {
            //Debug.Log("SlotFilled");
            isCompleted = true;
            WaveController.wave_complete = true;
        }

    }
}
