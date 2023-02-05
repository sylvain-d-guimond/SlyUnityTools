using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCall : MonoBehaviour
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

    public void Call()
    {
        if (Animator != null)
        {
            Animator.Play(Parameter);
        }
    }
}
