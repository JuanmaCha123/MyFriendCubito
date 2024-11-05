using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButton : MonoBehaviour
{
    public QuestDisplay questDisplay;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))  
        {
            questDisplay.ShowQuestUIs();
        }

        if (Input.GetKeyUp(KeyCode.T))  
        {
            questDisplay.HideQuestUIs();
        }
    }
}
