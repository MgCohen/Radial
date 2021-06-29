using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class SpriteSizeFixer : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] Transform pivot;
    [SerializeField] float baseRadius;

    private void Start()
    {
        //SetSprite();
    }

    public void SetSprite()
    {
        sprite = GetComponent<SpriteRenderer>();
        var angle = pivot.rotation.eulerAngles.z;

        var size = sprite.bounds.size;
        Vector2 targetSize = transform.lossyScale;


        float maxSize = Mathf.Max(size.x, size.y);
        float maxTargetSize = targetSize.x;

        float limit = GetMaxSize(angle);

        maxTargetSize = Mathf.Clamp(maxTargetSize, 0, limit);

        var offset = maxSize / maxTargetSize;
        transform.localScale /= offset;

        SetSpritePos(angle);
    }

    float GetMaxSize(float angle)
    {
        var right = Vector3.right * 0.3f;
        var angled = Quaternion.AngleAxis(angle, transform.forward) * right;
        return Vector3.Distance(right, angled) * 0.9f;
    }

    void SetSpritePos(float angle)
    {
        sprite.transform.localPosition = Quaternion.AngleAxis(angle/2, transform.forward) * (Vector3.right * 0.3f);
    }


}
