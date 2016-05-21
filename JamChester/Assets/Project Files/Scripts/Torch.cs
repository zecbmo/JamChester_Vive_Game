using UnityEngine;
using System.Collections;



public class Torch : SteamVR_InteractableObject 
{
    private GameObject beam;
    private bool beam_bool = false;

    public override void StartUsing(GameObject usingObject) 
    {
        base.StartUsing(usingObject);
        TurnOnLight();

    }

    protected override void Start() {
        base.Start();
        beam = transform.Find("cone").gameObject;
        beam.SetActive(beam_bool);        
    }

    void TurnOnLight() 
    {
        beam_bool = !beam_bool;
        beam.SetActive(beam_bool);
    }
}
