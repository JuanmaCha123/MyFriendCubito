using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfCameraDestroyer: MonoBehaviour
{
    public float destroyDistance = 5f; 

    private void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < 0 || screenPos.x > Screen.width || screenPos.y < 0 || screenPos.y > Screen.height)
        {
            Destroy(gameObject); 
        }

    }
}
