using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Updater : MonoBehaviour
{
    public UnityEvent LoseLife;
    public UnityEvent UpdateHealth;

    public static UI_Updater Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
