using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Movement Data", order = 52)]
public class C_MovementData : ScriptableObject
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
}
