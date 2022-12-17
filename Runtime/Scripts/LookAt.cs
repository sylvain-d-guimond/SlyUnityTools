using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Target;
    public float Damper = 0.1f;
    public bool Invert;

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            var direction = Target.position - transform.position;
            if (Invert) { direction = direction * -1; }
            if (!direction.Equals(Vector3.zero))
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction), Time.deltaTime/Damper);
        }
    }
}
