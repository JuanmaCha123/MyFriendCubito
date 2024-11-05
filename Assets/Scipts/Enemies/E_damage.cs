using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_damage : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with player");
            C_Health playerHealth = collision.gameObject.GetComponent<C_Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
