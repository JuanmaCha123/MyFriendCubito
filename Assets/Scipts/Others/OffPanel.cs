using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffPanel : MonoBehaviour
{
    public GameObject panel;
    public KeyCode toggleKey = KeyCode.F1;

    void Update()
    {


        if (Input.GetKeyUp(toggleKey))
        {
            panel.SetActive(false);
        }
    }
}
