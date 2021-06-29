using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class ArcInteractable : RadialInteractable
{
    public SpriteMask angleMask;
    public SpriteMask baseMask;
    public SortingGroup sort;
    public Transform rotationPivot;
    public SpriteRenderer background;

    public SpriteSizeFixer fixer;


    public override void Set(RadialMenu context, Command command, int interactableCount, int index, Vector3 rotation, Transform pivot, float radius)
    {
        this.menu = context;
        this.command = command;
        this.radius = radius;

        transform.position = pivot.position;

        float angle = 360f / interactableCount;
        SetTransform(rotation, angle);
        fixer.SetSprite();
        rotationPivot.localRotation = Quaternion.Euler(rotation);
        SetMasks(index);

        render.sprite = command.sprite;
        background.transform.rotation = Quaternion.identity;
        animator.Close(true);
    }

    void SetTransform(Vector3 rotation, float angle)
    {
        rotation.z -= angle / 2;

        angleMask.transform.parent.localRotation = Quaternion.Euler(0, 0, angle);
        Debug.Log(angle);
        transform.localScale = new Vector3(radius, radius, 1);
        //render.transform.rotation = Quaternion.Euler(-rotation);
    }

    void SetMasks(int index)
    {
        background.sortingOrder = index;
        render.sortingOrder = index + 1;

        angleMask.frontSortingOrder = index;
        angleMask.backSortingOrder = index - 1;

        baseMask.frontSortingOrder = index;
        baseMask.backSortingOrder = index - 1;
    }



    public override void Interact()
    {
        command.Execute();
        menu.Close();
    }

}
