using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_damage : MonoBehaviour
{
    public int damageAmount = 40;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trap triggered");
            C_Health playerHealth = collision.gameObject.GetComponent<C_Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
