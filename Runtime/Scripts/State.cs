using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class State : MonoBehaviour
{
    [SerializeField]
    private bool _active;
    [SerializeField]
    private StateGroup _group;
    [SerializeField]
    private bool _default;

    public bool Active
    {
        get => _active;
        set
        {
            if (_active != value)
            {
                if (value)
                {
                    OnActivate.Invoke();
                    if (_group != null) 
                        _group.Activate(this);
                }
                else
                {
                    OnDeactivate.Invoke();
                }

                _active = value;
            }
        }
    }

    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    private void Awake()
    {
        if (_group != null) _group.States.Add(this);
    }

    private void Start()
    {
        if (_default) { Active = true; }
    }
}
