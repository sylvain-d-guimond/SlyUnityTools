using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] bool X;
    [SerializeField] bool Y;
    [SerializeField] bool Z;
    [SerializeField] float Smoothing = 0.1f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(X ? Target.position.x : transform.position.x,
                        Y ? Target.position.y : transform.position.y,
                        Z ? Target.position.z : transform.position.z), Time.deltaTime / Smoothing);
    }
}
