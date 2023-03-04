using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitCheckerBase : MonoBehaviour 
{
    [HideInInspector] public string targetTag;
    [HideInInspector] public LayerMask targetLayerMask;
    [HideInInspector] public bool isEnableTag;
    [HideInInspector] public bool isEnableLayerMask;

    public bool IsHit { get; protected set; }

    //--------------------------------------------------


}
