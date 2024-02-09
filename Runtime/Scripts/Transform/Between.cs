using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Between : MonoBehaviour
{
    [SerializeField] List<Transform> Targets;

    private void Update()
    {
        var sum = Vector3.zero;

        foreach (var t in Targets)
        {
            sum += t.transform.position;
        }

        transform.position = sum / Targets.Count;
    }
}
