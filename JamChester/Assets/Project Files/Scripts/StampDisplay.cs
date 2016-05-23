﻿using UnityEngine;
using System.Collections;

public class StampDisplay : MonoBehaviour {

    public bool stamped = false;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "STAMP")
        {
            stamped = false;
           // transform.localRotation = new Vector3(coll.transform.rotation.y,transform.rotation.y, transform.rotation.z);

            MeshRenderer mr = GetComponent<MeshRenderer>();
            mr.enabled = true;
        }
    }
}