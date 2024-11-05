using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NoLoseLifeQuest", menuName = "Quests/No Lose Life Quest")]
public class NoLoseLifeQuest : Quest
{
    private bool lostLife;

    private void OnEnable()
    {
        lostLife = false;
    }

    public void LoseLife()
    {
        lostLife = true;
    }

    public override bool IsCompleted()
    {
        return !lostLife;
    }

    public override float GetCompletionPercentage()
    {
        return lostLife ? 0f : 100f;
    }
}
