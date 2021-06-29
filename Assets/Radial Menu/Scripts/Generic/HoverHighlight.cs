using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HoverHighlight : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 originalScale;

    private void Start()
    {
        originalScale = target.localScale;
    }

    private void OnMouseEnter()
    {
        target.DOKill();
        target.DOScale(originalScale * 1.5f, 0.25f);
    }

    private void OnMouseExit()
    {
        target.DOKill();
        target.DOScale(originalScale, 0.25f);
    }
}
