using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface E_strategy { 
void Move(Rigidbody2D rb, float moveSpeed, Vector3 targetpos);
}
