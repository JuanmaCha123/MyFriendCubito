using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_SwitchTimer : MonoBehaviour
{
    public string sceneToLoad; 
    public float timeToWait;

    void Start()
    {
        StartCoroutine(SwitchSceneAfterTime());
    }

    private IEnumerator SwitchSceneAfterTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadScene();
    }

    private void LoadScene()
    {
          SceneManager.LoadScene(sceneToLoad);
        
      
    }
}
