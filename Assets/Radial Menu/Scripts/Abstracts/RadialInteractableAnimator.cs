using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RadialInteractableAnimator : MonoBehaviour
{
    public abstract void Open(bool instant = false);
    public abstract void Close(bool instant = false);
}
