using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : PlayerAction<Vector3>
{

    public GameObject bullet;
    public int fireRatio;
    public float angleDeviation;

    public override void Act(Vector3 pos)
    {
        StartCoroutine(ShotCO(pos));
    }

    public override void Set()
    {
        Aim.Set(Act, this);
    }

    IEnumerator ShotCO(Vector3 pos)
    {
        for (int i = 0; i < fireRatio; i++)
        {
            var b = Instantiate(bullet, transform.position, Quaternion.identity);
            var direction = pos - transform.position;
            direction = deviation(direction, Random.Range(-angleDeviation, angleDeviation));
            b.transform.right = direction;
            yield return new WaitForSeconds(0.1f);
        }
    }

    Vector3 deviation(Vector3 direction, float angle)
    {
        direction = Quaternion.AngleAxis(angle, Vector3.forward) * direction;
        return direction;
    }
}
