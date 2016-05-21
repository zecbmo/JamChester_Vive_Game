using UnityEngine;
using System.Collections;

public class UVTrophy : GenericTrophy
{

    public bool fingerprint_found = false;
    FingerPrint[] script;





    public override void ChildStartFunctions()
    {
        base.ChildStartFunctions();
        script = GetComponentsInChildren<FingerPrint>();
        child_completed = false;

    }



    public override void ChildUpdateFunctions()
    {
        base.ChildUpdateFunctions();

        foreach(FingerPrint f in script)
        {
            fingerprint_found = f.found;
        }
        

        if (fingerprint_found) 
        {
            rag_type = RagType.FINGERPRINT;
            child_completed = true;
        }
    }

}
