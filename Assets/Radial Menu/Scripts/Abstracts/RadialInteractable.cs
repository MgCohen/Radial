using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RadialInteractable : MonoBehaviour
{
    public RadialInteractableAnimator animator;
    public SpriteRenderer render;
    public float radius;
    protected Command command;
    protected RadialMenu menu;

    public abstract void Set(RadialMenu context, Command command, int interactableCount, int index, Vector3 rotation, Transform pivot, float radius);

    public abstract void Interact();

}
