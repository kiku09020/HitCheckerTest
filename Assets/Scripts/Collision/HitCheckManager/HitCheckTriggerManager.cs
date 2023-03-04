using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheckTriggerManager : HitCheckManagerBase<HitCheckTriggerBase>
{

    //--------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var hitChecker in hitCheckerList) {
            hitChecker.OnHitTriggerEnter(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        foreach (var hitChecker in hitCheckerList) {
            hitChecker.OnHitTriggerStay(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (var hitChecker in hitCheckerList) {
            hitChecker.OnHitTriggerExit(collision);
        }
    }
}
