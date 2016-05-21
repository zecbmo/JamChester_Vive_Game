using UnityEngine;
using System.Collections;

public class UVTrophy : GenericTrophy
{

    public bool fingerprint_found = false;
    FingerPrint script;



    public override void ChildStartFunctions()
    {
        base.ChildStartFunctions();
        script = GetComponentInChildren<FingerPrint>();
        child_completed = false;

    }


    public override void ChildUpdateFunctions()
    {
        base.ChildUpdateFunctions();

        //stamped = sd.stamped;
        fingerprint_found = script.found;

        if (fingerprint_found) 
        {
            rag_type = RagType.FINGERPRINT;
            child_completed = true;
        }
    }
}
