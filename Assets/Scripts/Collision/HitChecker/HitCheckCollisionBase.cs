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

                    // ���C���[���^�O
                    if (isEnableTag) {
                        if (collision.gameObject.tag == targetTag) {
                            action?.Invoke();
                        }
                    }

                    // ���C���[�̂ݔ���
                    else {
                        action?.Invoke();
                    }
                }
            }

            // �^�O�̂ݔ���
            else if (isEnableTag && collision.gameObject.tag == targetTag) {
                action?.Invoke();
            }
        }
    }

    //--------------------------------------------------

    /// <summary>
    /// �����������̏���
    /// </summary>
    protected abstract void HitEnterAction(Collision2D collision);

    /// <summary>
    /// �������Ă��鎞�̏���
    /// </summary>
    protected virtual void HitStayAction(Collision2D collision) { }

    /// <summary>
    /// ���ꂽ���̏���
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
