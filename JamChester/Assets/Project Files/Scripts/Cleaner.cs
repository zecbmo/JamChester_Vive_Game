﻿using UnityEngine;
using System.Collections;

public enum CleanerType { NONE, BLUE, GREEN, PURPLE};

public class Cleaner : SteamVR_InteractableObject
{
    [Header("Cleaner Stuff")]
    private GameObject spray;
    public float spray_speed = 1000f;
    public float spray_life = 5f;
    public CleanerType cleaner_type = CleanerType.BLUE;

    //sound
    GameObject SoundManager;
    Sound sound_manager;

    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        FireSpray();
    }

    protected override void Start()
    {
        base.Start();
        spray = this.transform.Find("Spray").gameObject;
        SoundManager = GameObject.FindGameObjectWithTag("SOUND");
        sound_manager = SoundManager.GetComponent<Sound>();
    }

    void FireSpray()
    {
        sound_manager.PlaySFX(Sound.SFX.SPRAY);
        GameObject spray_clone = Instantiate(spray, spray.transform.position, Quaternion.identity) as GameObject;
        spray_clone.SetActive(true);
        Rigidbody rb = spray_clone.GetComponent<Rigidbody>();
        Spray script = spray_clone.GetComponent<Spray>();
        script.cleaner_type = cleaner_type;
        rb.AddRelativeForce(-transform.forward * spray_speed);

      
        Destroy(spray_clone, spray_life);



    }
}
