using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeQuest", menuName = "Quests/Complete In Time Quest")]
public class CompleteInTimeQuest : Quest
{
    public float timeLimit;
    private float startTime;

    public void StartTimer()
    {
        startTime = Time.time;
    }

    public override bool IsCompleted()
    {
        return Time.time - startTime <= timeLimit;
    }

    public override float GetCompletionPercentage()
    {
        float elapsedTime = Time.time - startTime;
        return Mathf.Clamp01(elapsedTime / timeLimit) * 100f;
    }
}