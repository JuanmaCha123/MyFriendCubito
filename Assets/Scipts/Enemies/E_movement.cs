using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_movement : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed = 2f;

    private Vector3 leftPos;
    private Vector3 rightPos;
    private bool movingRight = true;
    private Rigidbody2D rb;
    private E_strategy currentStrategy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftPos = leftPoint.position;
        rightPos = rightPoint.position;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
        currentStrategy = new E_MoveRightStrategy();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {

        currentStrategy.Move(rb, moveSpeed, movingRight ? rightPos : leftPos);

        if (movingRight && rb.transform.position.x >= rightPos.x)
        {
            movingRight = false;
            currentStrategy = new E_MoveLeftStrategy();
        }
        else if ((!movingRight && rb.transform.position.x <= leftPos.x))
        {
            movingRight = true;
            currentStrategy = new E_MoveRightStrategy();
        }
    }
}
