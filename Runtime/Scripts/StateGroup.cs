using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class StateGroup : MonoBehaviour
{
    public List<State> States;
    public GroupTypes Type;

    public void Activate(State state)
    {
        if (Type == GroupTypes.Single)
        {
            foreach (var aState in States)
            {
                if (aState!= state)
                {
                    aState.Active = false;
                }
            }
        }
    }

    public void Deactivate()
    {
        foreach (var aState in States)
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