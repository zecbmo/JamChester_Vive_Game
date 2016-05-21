using UnityEngine;
using System.Collections;

public class UVTrophy : GenericTrophy
{

    public bool stamped = false;
    FingerPrint script;

    private bool finger_print_found = false;


    public override void ChildStartFunctions()
    {
        base.ChildStartFunctions();
        script = GetComponentInChildren<FingerPrint>();
    }


    public override void ChildUpdateFunctions()
    {
        base.ChildUpdateFunctions();

        //stamped = sd.stamped;
    }
}
