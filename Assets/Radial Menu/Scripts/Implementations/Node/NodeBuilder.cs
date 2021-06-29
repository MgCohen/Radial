using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBuilder : RadialBuilder
{
    public float spacing;
    public float minRadius;

    public override List<RadialInteractable> Build(RadialMenu context, List<Command> commands, RadialInteractable interactable, Transform pivot)
    {
        List<RadialInteractable> interactables = new List<RadialInteractable>();

        int count = commands.Count;
        float angle = 360f / count;
        float interactableRadius = interactable.radius;
        float circumference = (interactableRadius + spacing) * count;
        float radius = circumference / (2 * Mathf.PI);
        radius = Mathf.Clamp(radius, minRadius, Mathf.Infinity);

        for (int i = 0; i < commands.Count; i++)
        {
            RadialInteractable newInteractable = Instantiate(interactable, pivot);
            newInteractable.Set(context, commands[i], count, i, new Vector3(0, 0, angle * i), pivot, radius);
            interactables.Add(newInteractable);
        }

        return interactables;
    }
}
