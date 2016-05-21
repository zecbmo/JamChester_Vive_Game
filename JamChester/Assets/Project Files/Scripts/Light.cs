using UnityEngine;
using System.Collections;

public class Light : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "FINGERPRINTS")
        {
            MeshRenderer mr = coll.GetComponent<MeshRenderer>();
            mr.enabled = true;
            FingerPrint f = coll.GetComponent<FingerPrint>();
            f.found = true;
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "FINGERPRINTS")
        {
            MeshRenderer mr = coll.GetComponent<MeshRenderer>();
            mr.enabled = false;

        }
    }
}
