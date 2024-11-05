using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CollectCoinsQuest", menuName = "Quests/Collect Coins Quest")]
public class CollectCoinsQuest : Quest
{
    public int requiredCoins;
    private int currentCoins = 0;

    public void AddCoin()
    {
        currentCoins++;
        Debug.Log($"Current coins: {currentCoins}");
        if (IsCompleted())
        {
            Debug.Log($"{questName} completed!");
        }
    }

    public override bool IsCompleted()
    {
        return currentCoins >= requiredCoins;
    }

    public override float GetCompletionPercentage()
    {
        if (requiredCoins <= 0)
            return 0f;
        return (float)currentCoins / requiredCoins * 100f;
    }

    public void Reset()
    {
        currentCoins = 0;
    }
}