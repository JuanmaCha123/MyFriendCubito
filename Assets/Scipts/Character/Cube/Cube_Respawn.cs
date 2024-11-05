using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Respawn : MonoBehaviour
{
    private Camera mainCamera;
    private Transform playerTransform;
    private bool isOutOfBounds = false;
    private float outOfBoundsTime = 0f;
    public float respawnDelay = 3f;
    public float spawnDistance = 0.5f; // Distancia de aparición desde el jugador

    void Start()
    {
        mainCamera = Camera.main;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x < 0 || viewportPosition.x > 1 ||
            viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            if (!isOutOfBounds)
            {
                isOutOfBounds = true;
                outOfBoundsTime = Time.time;
            }
            else
            {
                if (Time.time - outOfBoundsTime >= respawnDelay)
                {
                    TeleportCube();
                }
            }
        }
        else
        {
            isOutOfBounds = false;
        }
    }

    void TeleportCube()
    {
        
        Vector3 newPosition = playerTransform.position;

        
        float direction = playerTransform.localScale.x;

        
        newPosition.x -= spawnDistance * direction;

        transform.position = newPosition;
        isOutOfBounds = false; 
    }
}
