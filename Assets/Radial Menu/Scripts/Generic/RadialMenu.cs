using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    //prefab
    [SerializeField]
    RadialInteractable interactablePrefab;

    //build method
    [SerializeField]
    RadialBuilder builder;

    [SerializeField]
    RadialAnimationController animator;

    //pivot to instantiate
    [SerializeField]
    Transform pivot;

    //flag for current menu state
    bool isOpen = false;

    public List<RadialInteractable> _interactables
    {
        get { return interactables; }
    }

    List<RadialInteractable> interactables = new List<RadialInteractable>();


    public void Build(List<Command> commands)
    {
        if (interactables.Count > 0) DestroyInteractables();

        interactables = builder.Build(this, commands, interactablePrefab, pivot);
    }

    void DestroyInteractables()
    {
        foreach(var interactable in interactables)
        {
            Destroy(interactable.gameObject);
        }

        interactables.Clear();
    }

    public void Open()
    {
        if (interactables.Count <= 0) return;

        animator.Open(interactables);
        isOpen = true;
    }

    public void Close()
    {
        animator.Close(interactables);
        isOpen = false;
    }

    public void Toggle()
    {
        if (isOpen) Close();
        else Open();
    }

}
