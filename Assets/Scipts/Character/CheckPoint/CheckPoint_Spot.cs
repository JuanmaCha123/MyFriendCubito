using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint_Spot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            C_CheckPoint playerRespawn = collision.GetComponent<C_CheckPoint>();
            if (playerRespawn != null)
            {
                playerRespawn.SetCheckpoint(transform.position);
            }

        }
    }
}

