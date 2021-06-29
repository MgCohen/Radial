using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using System.Threading.Tasks;

public static class Aim
{
    static Action<Vector3> action;

    static Coroutine aimingRoutine;

    public static void Set<T>(Action<Vector3> act, T caller) where T : PlayerAction<Vector3>
    {
        if (aimingRoutine != null) caller.StopCoroutine(aimingRoutine);
        action = act;
        aimingRoutine = caller.StartCoroutine(Aiming());
    }

    static void Execute(Vector3 pos)
    {
        action.Invoke(pos);
    }

    static IEnumerator Aiming()
    {
        Vector3 pos = new Vector3();
        while (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            yield return null;
        }
        pos.z = 0;
        Execute(pos);

    }


}
