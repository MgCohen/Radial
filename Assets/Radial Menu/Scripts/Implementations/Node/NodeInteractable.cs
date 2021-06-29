using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInteractable : RadialInteractable
{

    [SerializeField]
    Transform node;

    public override void Set(RadialMenu context, Command command, int interactableCount, int index, Vector3 rotation, Transform pivot, float radius)
    {
        this.command = command;
        this.radius = radius;
        this.menu = context;
        transform.localRotation = Quaternion.Euler(rotation);
        transform.position = pivot.position + (transform.right * radius);
        node.rotation = Quaternion.identity;
        render.sprite = command.sprite;
        animator.Close(true);
    }

    public override void Interact()
    {
        command.Execute();
        menu.Close();
    }
}
