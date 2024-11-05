using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public C_Health playerHealth;

    void Start()
    {
        if (healthBarImage == null || playerHealth == null)
        {
            Debug.LogError("not assigned.");
            return;
        }
    }

    public void UpdateHealthBar()
    {
        if (healthBarImage != null && playerHealth != null)
        {
            healthBarImage.fillAmount = (float)playerHealth.currentHealth / playerHealth.healthData.maxHealth;
        }
    }
}

