using UnityEngine;
using System.Collections;

public enum CleanerType { NONE, C_1, C_2, C_3};

public class Cleaner : SteamVR_InteractableObject
{
    [Header("Cleaner Stuff")]
    private GameObject spray;
    public float spray_speed = 1000f;
    public float spray_life = 5f;
    public CleanerType cleaner_type = CleanerType.C_1;

    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        FireSpray();
    }

    protected override void Start()
    {
        base.Start();
        spray = this.transform.Find("Spray").gameObject;
    }

    void FireSpray()
    {
        GameObject spray_clone = Instantiate(spray, spray.transform.position, Quaternion.identity) as GameObject;
        spray_clone.SetActive(true);
        Rigidbody rb = spray_clone.GetComponent<Rigidbody>();
        Spray script = spray_clone.GetComponent<Spray>();
        script.cleaner_type = cleaner_type;
        rb.AddRelativeForce(-transform.forward * spray_speed);
        Destroy(spray_clone, spray_life);
    }
}
