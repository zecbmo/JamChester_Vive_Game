using UnityEngine;
using System.Collections;

public enum RagType { NONE, BRUSH, SPONGE, FINGERPRINT};


public class Rag : MonoBehaviour
{
    [Header("Rag Stuff")]
    //Type and wheter the tasks for trophy completed
    public RagType type = RagType.BRUSH;
    

}
