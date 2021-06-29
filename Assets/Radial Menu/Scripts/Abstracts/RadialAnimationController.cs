using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RadialAnimationController : MonoBehaviour
{
    protected bool isOpen;

    public abstract void Open(List<RadialInteractable> interactables);

    public abstract void Close(List<RadialInteractable> interactables);
}
