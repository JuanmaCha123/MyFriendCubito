using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_buttoms : MonoBehaviour
{
    
    public void LoadTitle()
    {
        SceneManager.LoadScene("title");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("levelSelector");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("lvl2");
    }

    public void QuitGame()
    {

          Application.Quit(); 

    }
}
