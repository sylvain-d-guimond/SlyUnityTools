using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[ExecuteInEditMode]
public class EffectBillboard : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;

    private void OnEnable()
    {
        FixedUpdate();

        StartCoroutine(CoDelay());
    }

    private IEnumerator CoDelay()
    {
        yield return null;

        SetChildrenEnabled(true);
    }

    private void OnDisable()
    {
        SetChildrenEnabled(false);
    }

    private void SetChildrenEnabled(bool enabled)
    {
        for (int i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(enabled);
        }
    }

    public void SetPointA(Transform t)
    {
        PointA = t;
    }

    public void SetPointB(Transform t)
    {
        PointB = t;
    }

    void FixedUpdate()
    {
        if (PointA != null && PointB != null)
        {
            var fingerSpan = PointB.position - PointA.position;
            var midpoint = PointA.position + (fingerSpan) / 2;
            transform.position = midpoint;
            var scale = fingerSpan.magnitude;
            transform.localScale = new Vector3(scale, scale, scale);
            var firstCross = Vector3.Cross(fingerSpan, Camera.main.transform.position - midpoint);
            var secondCross = Vector3.Cross(fingerSpan, firstCross);
            if (firstCross != Vector3.zero && secondCross != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(firstCross, secondCross);
            }
        }
    }
}
