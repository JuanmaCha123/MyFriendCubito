using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform_Elevator : MonoBehaviour
{
    public Transform elevator;
    public float elevatorSpeed = 2f;
    public Transform topPosition;
    public Transform bottomPosition;
    public LayerMask cubeLayer;

    private bool isCubeOnPlate = false;
    private AudioSource elevatorSound;
    private bool isMoving = false;

    void Start()
    {
        elevatorSound = GetComponent<AudioSource>();
        if (elevatorSound == null)
        {
            Debug.LogWarning("No AudioSource ");
        }
        else
        {
            elevatorSound.loop = true;
        }
    }

    void Update()
    {
        MoveElevator();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & cubeLayer) != 0)
        {
            isCubeOnPlate = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & cubeLayer) != 0)
        {
            isCubeOnPlate = false;
        }
    }

    void MoveElevator()
    {
        Vector2 targetPosition = isCubeOnPlate ? bottomPosition.position : topPosition.position;

        if ((Vector2)elevator.position != targetPosition)
        {
            elevator.position = Vector2.MoveTowards(elevator.position, targetPosition, elevatorSpeed * Time.deltaTime);
            if (!isMoving)
            {
                isMoving = true;
                if (elevatorSound != null && !elevatorSound.isPlaying)
                {
                    elevatorSound.Play();
                }
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                if (elevatorSound != null && elevatorSound.isPlaying)
                {
                    elevatorSound.Stop();
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
        Gizmos.DrawLine(topPosition.position, bottomPosition.position);
    }
}
