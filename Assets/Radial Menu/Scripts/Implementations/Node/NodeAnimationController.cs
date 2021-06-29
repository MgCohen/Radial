using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class NodeAnimationController : RadialAnimationController
{

    public Transform body;
    public Transform shadow;

    public async override void Open(List<RadialInteractable> interactables)
    {
        if (isOpen) return;

        isOpen = true;

        body.DOKill();
        shadow.DOKill();
        body.DORotate(new Vector3(0, 0, 180), 360f).SetSpeedBased().SetEase(Ease.Linear);
        shadow.DORotate(new Vector3(0, 0, 180), 360f).SetSpeedBased().SetEase(Ease.Linear);

        foreach (var interactable in interactables)
        {
            if (!isOpen) return;
            interactable.animator.Open();
            await Task.Delay(50);
        }
    }

    public override void Close(List<RadialInteractable> interactables)
    {
        if (!isOpen) return;

        isOpen = false;

        body.DOKill();
        shadow.DOKill();
        body.DORotate(new Vector3(0, 0, 00), 360f).SetSpeedBased().SetEase(Ease.Linear);
        shadow.DORotate(new Vector3(0, 0, 00), 360f).SetSpeedBased().SetEase(Ease.Linear);

        foreach(var interactable in interactables)
        {
            interactable.animator.Close();
        }
    }

}
