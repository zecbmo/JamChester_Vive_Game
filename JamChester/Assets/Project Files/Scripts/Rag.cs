using UnityEngine;
using System.Collections;

public enum RagType { NONE, R_1, R_2, R_3, R_4};


public class Rag : MonoBehaviour
{
    [Header("Rag Stuff")]
    //Type and wheter the tasks for trophy completed
    public RagType type = RagType.R_1;
    

}
