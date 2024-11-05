using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestDisplay : MonoBehaviour
{
    public QuestManager questManager; 
    public GameObject questTitleTextPrefab;
    public Transform questTitleContainer;
    private List<TextMeshProUGUI> questTitleTexts = new List<TextMeshProUGUI>();

    void Start()
    {
        HideQuestUIs();

        CreateQuestUIs();
    }

    void Update()
    {
        UpdateQuestStatuses();
    }

    void CreateQuestUIs()
    {
        float yOffset = 160f; 
        for (int i = 0; i < questManager.quests.Count; i++)
        {
            Quest quest = questManager.quests[i];
            GameObject questTitleObj = Instantiate(questTitleTextPrefab, questTitleContainer);
            TextMeshProUGUI questTitleText = questTitleObj.GetComponent<TextMeshProUGUI>();
            questTitleText.text = $"{quest.questName}: {quest.description}";
            questTitleText.rectTransform.anchoredPosition = new Vector2(0, -i * yOffset);
            questTitleTexts.Add(questTitleText);
        }
    }

    void UpdateQuestStatuses()
    {
       
        for (int i = 0; i < questManager.quests.Count; i++)
        {
            Quest quest = questManager.quests[i];
            TextMeshProUGUI questTitleText = questTitleTexts[i];
            if (quest.IsCompleted())
            {
                questTitleText.color = Color.green;
            }
            else
            {
                questTitleText.color = Color.red;
            }
        }
    }
    public void HideQuestUIs()
    {
        questTitleContainer.gameObject.SetActive(false);
    }

    public void ShowQuestUIs()
    {
        questTitleContainer.gameObject.SetActive(true);
    }
}
