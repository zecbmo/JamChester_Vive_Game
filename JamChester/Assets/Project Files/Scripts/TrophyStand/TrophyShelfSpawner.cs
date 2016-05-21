using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TrophyShelfSpawner : MonoBehaviour {
      
    List<TrophyShelf> shelfList = new List<TrophyShelf>();
    public TrophyShelf shelfPrefab;
    public float rowHeight = 0;

    // Use this for initialization
    void Start() {
        SpawnNewRow();
    }

    public void AddType(TrophyType type) {
        shelfPrefab.AddType(type);
    }

    // Update is called once per frame
    void Update () {
        if(shelfList.Last().isCompleted){
            SpawnNewRow();                        
        }
    }    

    public void SpawnNewRow() {
        foreach (TrophyShelf shelf in shelfList) {
            shelf.MoveShelf(new Vector3(0, rowHeight, 0));
        }
        shelfList.Add(Instantiate(shelfPrefab,transform.position,Quaternion.identity) as TrophyShelf);
        shelfList.Last().gameObject.SetActive(true);
    }    
}
