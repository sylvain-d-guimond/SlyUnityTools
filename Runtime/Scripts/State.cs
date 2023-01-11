using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class State : MonoBehaviour
{
    [SerializeField]
    private bool _active;
    [SerializeField]
    private State _parent;
    [SerializeField]
    private bool _default;
    [SerializeField]
    private GroupTypes _type;
    private bool _initialized;
    private List<State> _subStates = new List<State>();

    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    public bool Active
    {
        get => _active;
        set
        {
            if (_active != value || !_initialized)
            {
                if (value)
                {
                    OnActivate.Invoke();
                    if (_parent != null && _parent._type == GroupTypes.Single)
                        _parent.DeactivateOthers(this);

                    ActivateDefault();
                }
                else
                {
                    OnDeactivate.Invoke();
                }

                gameObject.SetActive(_active = value);
                _initialized = true;
            }
        }
    }

    private void Awake()
    {
        if (_parent != null) _parent.AddChild(this);
    }

    private void Start()
    {
        if (_parent == null) ActivateDefault();
    }

    public void AddChild(State aState)
    {
        _subStates.Add(aState);
    }

    public void ActivateDefault()
    {
        foreach (var child in _subStates)
        {
            if (child._default) child.Active = true;
        }
    }

    public void DeactivateOthers(State state)
    {
        if (_type == GroupTypes.Single)
        {
            foreach (var aState in _subStates)
            {
                if (aState != state)
                {
                    aState.Active = false;
                }
            }
        }
    }

    public void Deactivate()
    {
        foreach (var aState in _subStates)
        {
            aState.Active = false;
        }
    }
}

public enum GroupTypes
{
    Single,
    Multiple
}

