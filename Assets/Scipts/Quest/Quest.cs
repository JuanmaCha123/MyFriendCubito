using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : ScriptableObject
{
    public string questName;
    public string description;

    public abstract bool IsCompleted();
    public abstract float GetCompletionPercentage();
}