using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(VisualEffect))]
public class SetVFXFloat : MonoBehaviour
{
    public string Parameter;

    private VisualEffect _vfx;

    private void Awake()
    {
        _vfx = GetComponent<VisualEffect>();
    }

    public void Set(float value)
    {
        _vfx.SetFloat(Parameter, value);
    }
}
