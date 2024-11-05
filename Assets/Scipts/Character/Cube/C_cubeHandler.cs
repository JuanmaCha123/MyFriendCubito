using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_cubeHandler : MonoBehaviour
{
    public Cube_ConfigData cubeConfig;

    private Transform playerTransform;
    private bool isCubeAttached = false;
    private GameObject attachedCube;
    private bool isCubeRepelled = false;
    private GameObject repelledCube;
    private int originalLayer;

    private Collider2D[] overlapResults = new Collider2D[10];

    public AudioClip grabSound;
    public AudioClip releaseSound;
    public AudioClip repelSound;

    private AudioSource audioSource;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();

        audioSource.loop = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isCubeAttached)
            {
                AttachCube();
            }
            else
            {
                DetachCube();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isCubeAttached)
            {
                DetachAndRepelCube();
            }
            else if (!isCubeRepelled)
            {
                RepelCube();
            }
        }

        if (isCubeAttached && attachedCube != null)
        {
            float direction = playerTransform.localScale.x;
            attachedCube.transform.position = playerTransform.position + new Vector3(direction * cubeConfig.distanceFromPlayer, 0, 0);
        }

        if (isCubeRepelled && repelledCube != null)
        {
            Rigidbody2D rb = repelledCube.GetComponent<Rigidbody2D>();
            if (rb != null && rb.velocity.magnitude < cubeConfig.velocityThreshold)
            {
                ResetCubeLayer();
                isCubeRepelled = false;
                repelledCube = null;
            }
        }
    }

    void AttachCube()
    {
        int numCubes = Physics2D.OverlapCircleNonAlloc(playerTransform.position, cubeConfig.attractionRadius, overlapResults, cubeConfig.cubeLayer);

        if (numCubes > 0)
        {
            Collider2D cube = overlapResults[0];
            attachedCube = cube.gameObject;
            isCubeAttached = true;

            float direction = playerTransform.localScale.x;
            Vector3 newPosition = playerTransform.position + new Vector3(direction * cubeConfig.distanceFromPlayer, 0, 0);
            attachedCube.transform.position = newPosition;

            PlaySound(grabSound);
        }
    }

    void DetachCube()
    {
        if (isCubeAttached && attachedCube != null)
        {
            isCubeAttached = false;
            attachedCube = null;

            PlaySound(releaseSound);
        }
    }

    void RepelCube()
    {
        int numCubes = Physics2D.OverlapCircleNonAlloc(transform.position, cubeConfig.repulsionRadius, overlapResults, cubeConfig.cubeLayer);

        for (int i = 0; i < numCubes; i++)
        {
            Collider2D cube = overlapResults[i];
            if (!isCubeRepelled)
            {
                Vector3 repulsionDirection = (cube.transform.position - playerTransform.position).normalized;
                cube.GetComponent<Rigidbody2D>().AddForce(repulsionDirection * cubeConfig.repulsionForce, ForceMode2D.Impulse);
                repelledCube = cube.gameObject;
                originalLayer = repelledCube.layer;
                repelledCube.layer = LayerMask.NameToLayer("repelledCube");
                isCubeRepelled = true;

                PlaySound(repelSound);
            }
        }
    }

    void DetachAndRepelCube()
    {
        if (isCubeAttached)
        {
            DetachCube();
            RepelCube();
        }
    }

    void ResetCubeLayer()
    {
        if (repelledCube != null)
        {
            repelledCube.layer = originalLayer;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, cubeConfig.attractionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, cubeConfig.repulsionRadius);
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = false;  
        audioSource.Play();
    }   
}
