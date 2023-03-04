using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class HitCheckTriggerBase : HitCheckerBase
{
    // BaseCheck(Trigger)
    void HitTriggerCheck(Collider2D collision, Action action)
    {
        if (enabled) {
            if (isEnableLayerMask && targetLayerMask.value != 0) {
                if (((1 << collision.gameObject.layer) & targetLayerMask) != 0) {

                    // レイヤーかつタグ
                    if (isEnableTag) {
                        if (collision.gameObject.tag == targetTag) {
                            action?.Invoke();
                        }
                    }

                    // レイヤーのみ判定
                    else {
                        action?.Invoke();
                    }
                }
            }

            // タグのみ判定
            else if (isEnableTag && collision.gameObject.tag == targetTag) {
                action?.Invoke();
            }
        }
    }

    //--------------------------------------------------

    /// <summary>
    /// 当たった時の処理
    /// </summary>
    protected abstract void HitEnterAction(Collider2D collision);

    /// <summary>
    /// 当たっている時の処理
    /// </summary>
    protected virtual void HitStayAction(Collider2D collision) { }

    /// <summary>
    /// 離れた時の処理
    /// </summary>
    protected abstract void HitExitAction(Collider2D collision);

    //--------------------------------------------------

    // TriggerEnter
    public void OnHitTriggerEnter(Collider2D collision)
    {
        HitTriggerCheck(collision, () => {
            IsHit = true;
            HitEnterAction(collision);
        });
    }

    // TriggerStay
    public void OnHitTriggerStay(Collider2D collision)
    {
        HitTriggerCheck(collision, () => {
            IsHit = true;
            HitStayAction(collision);
        });
    }

    // TriggerExit
    public void OnHitTriggerExit(Collider2D collision)
    {
        HitTriggerCheck(collision, () => {
            IsHit = false;
            HitExitAction(collision);
        });
    }
}
