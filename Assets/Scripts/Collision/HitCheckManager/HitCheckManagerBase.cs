using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitCheckManagerBase <T> : MonoBehaviour where T:HitCheckerBase 
{
    [SerializeField] protected List<T> hitCheckerList = new List<T>();

    //--------------------------------------------------

    /// <summary>
    /// Žw’è‚ÌHitChekcer‚ðŽæ“¾
    /// </summary>
    public HitChecker GetHitChecker<HitChecker>() where HitChecker:T
    {
        foreach (var hitCheckr in hitCheckerList) {
            if (hitCheckr is HitChecker target) {
                return target;
            }
        }

        print($"{nameof(HitChecker)} doesn`t exist.");
        return null;
    }
}
