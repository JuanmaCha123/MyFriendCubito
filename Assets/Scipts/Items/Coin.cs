using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private QuestManager questManager;
    private AudioSource pick;
    private SpriteRenderer sprite;
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        pick = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pick.Play();
            questManager.RegisterCoinCollected();
            sprite.sprite = null;
            StartCoroutine(DestroyAfterSound());
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(pick.clip.length);
        Destroy(gameObject);
    }
}