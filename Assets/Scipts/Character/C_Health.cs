using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Health : MonoBehaviour
{
    public C_HealthData healthData;
    public int currentHealth;  
    private C_lives playerLives;
    private C_CheckPoint checkPoint;
    private QuestManager questManager;
    private AudioSource damageAudioSource;

    void Start()
    {
        if (healthData != null)
        {
            ResetHealth();
            StartCoroutine(RegenerateHealth());
        }

        playerLives = GetComponent<C_lives>();
        checkPoint = GetComponent<C_CheckPoint>();
        questManager = FindObjectOfType<QuestManager>();

        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 3)
        {
            damageAudioSource = audioSources[3];
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (healthData != null)
        {
            currentHealth -= damageAmount;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
            Debug.Log($"{damageAmount} damage, current health: {currentHealth}");

            UI_Updater.Instance.UpdateHealth.Invoke();

            questManager.RegisterDamageTaken();

            if (damageAudioSource != null && damageAudioSource.clip != null)
            {
                damageAudioSource.Play();
            }

            if (IsDead())
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Debug.Log("Player died");

        if (playerLives != null)
        {
            playerLives.DecreaseLives();
        }

        if (healthData != null && checkPoint != null)
        {
            if (!playerLives.OutOfLives())
            {
                ResetHealth();
                UI_Updater.Instance.UpdateHealth.Invoke();
                checkPoint.Respawn();
            }
        }
    }

    private IEnumerator RegenerateHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(healthData.healthRegenInterval);

            if (currentHealth < healthData.maxHealth)
            {
                currentHealth += healthData.healthRegenAmount;
                if (currentHealth > healthData.maxHealth)
                {
                    currentHealth = healthData.maxHealth;
                }

                UI_Updater.Instance.UpdateHealth.Invoke();
            }
        }
    }

    public void ResetHealth()
    {
        currentHealth = healthData.maxHealth;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
