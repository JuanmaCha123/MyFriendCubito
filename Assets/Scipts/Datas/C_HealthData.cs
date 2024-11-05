using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHealthData", menuName = "Health Data", order = 51)]
public class C_HealthData : ScriptableObject
{
    public int maxHealth = 100;
    public int healthRegenAmount = 2;
    public float healthRegenInterval = 1f;
    public int maxLives = 3;
}