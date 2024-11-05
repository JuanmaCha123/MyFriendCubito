using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;

    void Start()
    {

        ResetCoinQuests();
        foreach (var quest in quests)
        {
            if (quest is CompleteInTimeQuest timeQuest)
            {
                timeQuest.StartTimer();
            }
        }
    }

    void Update()
    {
        CheckQuestStatus();
    }

    public void CheckQuestStatus()
    {
        foreach (var quest in quests)
        {
            if (quest.IsCompleted())
            {
                Debug.Log($"{quest.questName} is completed!");
            }
            else
            {
                Debug.Log($"{quest.questName} is not completed");
            }
        }
    }

    public float GetOverallCompletionPercentage()
    {
        float totalPercentage = 0;
        foreach (var quest in quests)
        {
            totalPercentage += quest.GetCompletionPercentage();
        }
        return totalPercentage / quests.Count;
    }

    public void RegisterCoinCollected()
    {
        foreach (var quest in quests)
        {
            if (quest is CollectCoinsQuest coinQuest)
            {
                coinQuest.AddCoin();
            }
        }
    }

    public void RegisterLifeLost()
    {
        foreach (var quest in quests)
        {
            if (quest is NoLoseLifeQuest noLoseLifeQuest)
            {
                noLoseLifeQuest.LoseLife();
            }
        }
    }

    public void RegisterDamageTaken()
    {
        foreach (var quest in quests)
        {
            if (quest is NoLoseLifeQuest noLoseLifeQuest)
            {
                noLoseLifeQuest.LoseLife();
            }
        }
    }

    void ResetCoinQuests()
    {
        foreach (var quest in quests)
        {
            if (quest is CollectCoinsQuest coinQuest)
            {
                coinQuest.Reset();
            }
        }
    }
}