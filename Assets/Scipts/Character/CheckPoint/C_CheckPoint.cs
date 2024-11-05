using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CheckPoint : MonoBehaviour
{
    private Vector3 currentCheckpoint;
    private C_Health playerHealth;

    void Start()
    {
        currentCheckpoint = transform.position;
        playerHealth = GetComponent<C_Health>();

        if (playerHealth != null)
        {
            playerHealth.ResetHealth();
        }
    }

    void Update()
    {
        if (playerHealth != null && playerHealth.IsDead())
        {
            Respawn();
        }
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint;
        if (playerHealth != null)
        {
            playerHealth.ResetHealth();
        }
    }
}


