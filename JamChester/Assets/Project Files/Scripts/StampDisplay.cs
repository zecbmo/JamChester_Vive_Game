using UnityEngine;
using System.Collections;

public class StampDisplay : MonoBehaviour {

    public bool stamped = false;
    Sound sound_manager;
    GameObject SoundManager;

    void Start() {
        SoundManager = GameObject.FindGameObjectWithTag("SOUND");
        sound_manager = SoundManager.GetComponent<Sound>();
    }


    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "STAMP")
        {
            stamped = true;
           // transform.localRotation = new Vector3(coll.transform.rotation.y,transform.rotation.y, transform.rotation.z);

            MeshRenderer mr = GetComponent<MeshRenderer>();
            mr.enabled = true;
            sound_manager.PlaySFX(Sound.SFX.STAMP);
            
        }
    }
}
