using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_MoveLeftStrategy : E_strategy
{
    public void Move(Rigidbody2D rb, float moveSpeed, Vector3 targetPos)
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        if (rb.transform.position.x <= targetPos.x)
        {
            rb.transform.localScale = new Vector3(1, 1, 1);

        }
    }
}
