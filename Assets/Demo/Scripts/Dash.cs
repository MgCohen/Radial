using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dash : PlayerAction<Vector3>
{
    public override void Act(Vector3 pos)
    {
        transform.DOKill();
        transform.DOMove(pos, 10).SetSpeedBased();
    }

    public override void Set()
    {
        Aim.Set(Act, this);
    }
}
