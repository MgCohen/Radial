using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HoverColor : MonoBehaviour
{
    Color originalColor;
    [SerializeField] SpriteRenderer sprite;

    [SerializeField] Color highlightColor;

    private void Start()
    {
        originalColor = sprite.color;
    }

    private void OnMouseEnter()
    {
        sprite.DOKill();
        sprite.DOColor(highlightColor, 0.25f);
    }

    private void OnMouseExit()
    {
        sprite.DOKill();
        sprite.DOColor(originalColor, 0.25f);
    }
}
