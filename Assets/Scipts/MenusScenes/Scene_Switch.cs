using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Switch : MonoBehaviour
{
    public string sceneToLoad; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("cubo"))
        {
            LoadScene();
        }

    }

    private void LoadScene()
    {
       
            SceneManager.LoadScene(sceneToLoad);
        
     
    }
}
