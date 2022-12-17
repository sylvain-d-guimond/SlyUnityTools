using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBoolTrigger : MonoBehaviour
{
    public string Parameter;
    public Animator Animator;

    private void Awake()
    {
        if (Animator == null)
        {
            Animator = GetComponent<Animator>();
        }
    }

    public bool Value
    {
        get {
            if (Animator != null) return Animator.GetBool(Parameter);
            else return false;
        }
        set { if (Animator != null) Animator.SetBool(Parameter, value); }
    }
}
