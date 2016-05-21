using UnityEngine;
using System.Collections;

public class FingerPrint : MonoBehaviour {

    public bool found = false;
    MeshRenderer rend;

    void Start() 
    {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = false;
    }

    void OnTriggerEnter(Collider coll) 
    {
        if (coll.tag == "TORCH") 
        {
            rend.enabled = true;
            found = true;
        }
    }
}
