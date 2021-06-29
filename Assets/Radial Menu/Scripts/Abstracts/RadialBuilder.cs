using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RadialBuilder : MonoBehaviour
{
    public abstract List<RadialInteractable> Build(RadialMenu context, List<Command> commands, RadialInteractable interactable, Transform pivot);
}
