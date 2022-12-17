using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : Singleton<DebugMode>
{
    public DebugLevels DebugLevel;
}

public enum DebugLevels
{
    Debug,
    Info,
    Message,
    Warning,
    Error
}
