using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcBuilder : RadialBuilder
{

    [SerializeField] float range;

    public override List<RadialInteractable> Build(RadialMenu context, List<Command> commands, RadialInteractable interactable, Transform pivot)
    {
        List<RadialInteractable> interactables = new List<RadialInteractable>();
        int count = commands.Count;
        float angle = 360f / count;

        for (int i = 0; i < commands.Count; i++)
        {
            RadialInteractable newInteractable = Instantiate(interactable, pivot);
            newInteractable.Set(context, commands[i], count, i ,new Vector3(0, 0, angle * i), pivot, range);
            interactables.Add(newInteractable);
        }
        Debug.Log(interactables.Count);
        return interactables;
    }
}
