using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class HitCheckCollisionBase : HitCheckerBase
{
    // BaseCheck(Collision)
    void HitCheck(Collision2D collision, Action action)
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
    protected abstract void HitEnterAction(Collision2D collision);

    /// <summary>
    /// 当たっている時の処理
    /// </summary>
    protected virtual void HitStayAction(Collision2D collision) { }

    /// <summary>
    /// 離れた時の処理
    /// </summary>
    protected abstract void HitExitAction(Collision2D collision);

    //--------------------------------------------------

    // CollisionEnter
    public void OnHitEnter(Collision2D collision)
    {
        HitCheck(collision, () => {
            IsHit = true;
            HitEnterAction(collision);
        });
    }

    // CollisionStay
    public void OnHitStay(Collision2D collision)
    {
        HitCheck(collision, () => {
            IsHit = true;
            HitStayAction(collision);
        });
    }

    // CollisionExit
    public void OnHitExit(Collision2D collision)
    {
        HitCheck(collision, () => {
            IsHit = false;
            HitExitAction(collision);
        });
    }
}
