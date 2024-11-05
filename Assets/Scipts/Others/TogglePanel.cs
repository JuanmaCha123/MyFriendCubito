using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject panel; 
    public KeyCode toggleKey = KeyCode.F1; 

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            panel.SetActive(true); 
        }

        if (Input.GetKeyUp(toggleKey))
        {
            panel.SetActive(false);
        }
    }
}
