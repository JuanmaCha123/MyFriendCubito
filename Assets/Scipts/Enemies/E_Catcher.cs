using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Catcher : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRadius = 5f;
    public LayerMask playerLayer;

    private bool isChasing = false;
    private Transform playerTransform;
    private Rigidbody2D rb;
    private E_movement patrolScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        patrolScript = GetComponent<E_movement>();
    }

    void Update()
    {
        DetectPlayer();

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            patrolScript.enabled = true;
        }
    }

    void DetectPlayer()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        if (player != null)
        {
            playerTransform = player.transform;
            isChasing = true;
            patrolScript.enabled = false;
        }
        else
        {
            isChasing = false;
        }
    }

    void ChasePlayer()
    {
        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

            if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
