using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCompletionPoint : MonoBehaviour
{
    private QuestManager questManager;

    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            questManager.CheckQuestStatus();
        }
    }
}
