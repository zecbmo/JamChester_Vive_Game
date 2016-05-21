using UnityEngine;
using System.Collections;

public class LooseScreen : MonoBehaviour {

    MeshRenderer mr;
	// Use this for initialization
	void Start () {
        
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Globals.game_state ==  GameState.LOST)
        {

            mr.enabled = true;
        }
        
	}
}
