using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TrophyShelfSpawner : MonoBehaviour {
      
    List<TrophyShelf> shelfList = new List<TrophyShelf>();
    public TrophyShelf shelfPrefab;
    public GameObject top;
    public float rowHeight = 0;

    public int availableSlots = 0;

    // Use this for initialization
    void Start() {
        top.gameObject.transform.Translate(new Vector3(0, rowHeight, 0));
        foreach (TrophyShelf shelf in shelfList) {
            shelf.MoveShelf(new Vector3(0, rowHeight, 0));
        }
        shelfList.Add(Instantiate(shelfPrefab, transform.position, Quaternion.identity) as TrophyShelf);
        availableSlots += 4;
        shelfList.Last().gameObject.SetActive(true);
        shelfList.Last().CreateSlots();
        top.gameObject.transform.parent = shelfList.Last().gameObject.transform;
    }

    // Update is called once per frame
    void Update () {
        if(shelfList.Last().isCompleted){
            SpawnNewRow();           
        }
    }    

    public void SpawnNewRow() {
        //Debug.Log("NewRow");
        shelfList.Add(Instantiate(shelfPrefab,transform.position, Quaternion.identity) as TrophyShelf);        
        availableSlots += 4;
        shelfList.Last().gameObject.SetActive(true);
        shelfList.Last().CreateSlots();
        shelfList.Last().gameObject.transform.position -= new Vector3(0, rowHeight, 0);
       // shelfList.Last().transform.position -= new Vector3(0, rowHeight, 0);
       foreach (TrophyShelf shelf in shelfList) {
            shelf.MoveShelf(new Vector3(0, rowHeight, 0));
        }
        
    }    
}
