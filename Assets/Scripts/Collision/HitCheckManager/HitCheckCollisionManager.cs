using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheckCollisionManager : HitCheckManagerBase<HitCheckCollisionBase> {

    //--------------------------------------------------

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var hitChecker in hitCheckerList) {
            hitChecker.OnHitEnter(collision);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (var hitChecker in hitCheckerList) {
            hitChecker.OnHitStay(collision);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        foreach (var hitChecker in hitCheckerList) {
            hitChecker.OnHitExit(collision);
        }
    }

    //--------------------------------------------------


}