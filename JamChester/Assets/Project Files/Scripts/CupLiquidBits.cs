using UnityEngine;
using System.Collections;

public class CupLiquidBits : MonoBehaviour {

    // Use this for initialization
    private GameObject parent_trophy;

    public void SetParent(GameObject parent)
    {
        parent_trophy = parent;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "HEAD")
        {
            CupTrophy ct = parent_trophy.GetComponent<CupTrophy>();
            ct.drank = true;
        }
    }
}
