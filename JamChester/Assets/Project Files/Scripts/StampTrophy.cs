using UnityEngine;
using System.Collections;

public class StampTrophy : GenericTrophy {

   
    StampDisplay sd;
    public override void ChildStartFunctions()
    {
        base.ChildStartFunctions();
        sd = GetComponentInChildren<StampDisplay>();
        child_completed = false;
    }


    public override void ChildUpdateFunctions()
    {
        base.ChildUpdateFunctions();

        child_completed = sd.stamped;
    }
}
