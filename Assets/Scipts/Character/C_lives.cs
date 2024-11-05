using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class C_lives : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public C_HealthData healthData;
    public int currentLives;  

    void Start()
    {
        if (healthData != null)
        {
            ResetLives();
            UpdateLivesUI();
        }
    }

    public void DecreaseLives()
    {
        if (healthData != null)
        {
            LoseLife();
            UI_Updater.Instance.LoseLife.Invoke();
            if (OutOfLives())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void UpdateLivesUI()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = $"{currentLives}";
        }
    }

    public void ResetLives()
    {
        currentLives = healthData.maxLives;
    }

    public void LoseLife()
    {
        currentLives--;
    }

    public bool OutOfLives()
    {
        return currentLives <= 0;
    }
}
