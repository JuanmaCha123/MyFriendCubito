using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_movement : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento de la trampa
    public float moveDistance = 3f; // Distancia total que la trampa se moverá hacia arriba y hacia abajo
    public float waitTime = 2f; // Tiempo que la trampa espera antes de volver a subir

    private Vector3 startPosition; // Posición inicial de la trampa
    private bool isMovingUp = true; // Indica si la trampa se está moviendo hacia arriba
    private bool isWaiting = false; // Indica si la trampa está esperando
    private float timer = 0f; // Temporizador para la espera

    void Start()
    {
        startPosition = transform.position; // Guardar la posición inicial de la trampa
    }

    void Update()
    {
        if (isWaiting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                isWaiting = false;
                isMovingUp = !isMovingUp;
            }
        }
        else
        {
            MoveTrap();
        }
    }

    void MoveTrap()
    {
        if (isMovingUp)
        {
            transform.position = new Vector3(startPosition.x, Mathf.MoveTowards(transform.position.y, startPosition.y + moveDistance, moveSpeed * Time.deltaTime), startPosition.z);

            if (transform.position.y >= startPosition.y + moveDistance)
            {
                StartWait();
            }
        }
        else
        {
            transform.position = new Vector3(startPosition.x, Mathf.MoveTowards(transform.position.y, startPosition.y, moveSpeed * Time.deltaTime), startPosition.z);

            if (transform.position.y <= startPosition.y)
            {
                StartWait();
            }
        }
    }

    void StartWait()
    {
        isWaiting = true;
        timer = waitTime;
    }
}
