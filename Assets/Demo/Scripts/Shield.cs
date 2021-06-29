using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : PlayerAction<Vector3>
{

    [SerializeField] GameObject shieldPrefab;
    GameObject shield
    {
        get
        {
            if (_shield == null) _shield = Instantiate(shieldPrefab, transform);
            return _shield;
        }
    }
    GameObject _shield;
    Coroutine shieldRoutine;
    public float shieldTime;

    public override void Act(Vector3 pos)
    {
        if (shieldRoutine != null) StopCoroutine(shieldRoutine);
        StartCoroutine(ShieldCO(pos));

    }

    public override void Set()
    {
        Aim.Set(Act, this);
    }

    IEnumerator ShieldCO(Vector3 pos)
    {
        shield.SetActive(true);
        shield.transform.right = pos - transform.position;
        yield return new WaitForSeconds(shieldTime);
        shield.SetActive(false);
    }
}
