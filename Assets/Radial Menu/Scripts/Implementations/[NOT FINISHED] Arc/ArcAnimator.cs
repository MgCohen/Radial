using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ArcAnimator : RadialInteractableAnimator
{

    Vector3 localScale = Vector3.zero;
    public Collider2D col;

    public override void Close(bool instant = false)
    {
        if (localScale == Vector3.zero)
            localScale = transform.localScale;

        col.enabled = false;

        transform.DOKill();
        if (!instant)
            transform.DOScale(Vector3.zero, 3f).SetSpeedBased().SetEase(Ease.InBack).OnComplete(() => gameObject.SetActive(false));
        else
        {
            transform.localPosition = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

    public override void Open(bool instant = false)
    {
        transform.DOKill();
        gameObject.SetActive(true);
        col.enabled = true;
        if (!instant)
            transform.DOScale(localScale, 3f).SetSpeedBased().SetEase(Ease.OutBack);
        else
            transform.localScale = localScale;
    }
}
