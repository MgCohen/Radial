using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class NodeAnimator : RadialInteractableAnimator
{
    Vector3 localPos = Vector3.zero;
    public Collider2D col;

    public override void Open(bool instant = false)
    {
        transform.DOKill();
        gameObject.SetActive(true);
        col.enabled = true;
        if (!instant)
            transform.DOLocalMove(localPos, 3f).SetSpeedBased().SetEase(Ease.OutBack);
        else
            transform.localPosition = localPos;
    }

    public override void Close(bool instant = false)
    {
        if (localPos == Vector3.zero)
        localPos = transform.localPosition;

        col.enabled = false;

        transform.DOKill();
        if (!instant)
            transform.DOLocalMove(Vector3.zero, 3f).SetSpeedBased().SetEase(Ease.InBack).OnComplete(() => gameObject.SetActive(false));
        else
        {
            transform.localPosition = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}
