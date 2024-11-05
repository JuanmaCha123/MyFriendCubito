using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Collisions : MonoBehaviour
{
    private AudioSource damageDoor;
    private AudioSource damageEnemies;

    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        damageDoor = audioSources[1];
        damageEnemies = audioSources[0];





    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.layer == LayerMask.NameToLayer("repelledCube"))
        {
            
            if (collision.gameObject.layer == LayerMask.NameToLayer("door"))
            {
                damageDoor.Play();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                damageEnemies.Play();
                Destroy(collision.gameObject);
            }
        }
    }

}
