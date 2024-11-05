using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CubeConfig", menuName = "Cube Config", order = 53)]
public class Cube_ConfigData : ScriptableObject
{
    public float repulsionRadius = 5f;
    public float repulsionForce = 10f;
    public float attractionRadius = 5f;
    public float distanceFromPlayer = 0.2f;
    public LayerMask cubeLayer;
    public float velocityThreshold = 0.1f;
}
