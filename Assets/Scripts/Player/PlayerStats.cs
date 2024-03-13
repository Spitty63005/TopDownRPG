using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int CurrentLevel;
    public float CurrentHealth;
    public float MaxHealth;
    public float MaxMana;
    public float CurrentMana;


    public void ResetPlayer()
    {
        CurrentLevel = 1;
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
    }

    public void RevivePlayer()
    {
        CurrentHealth = MaxHealth / 2;
        CurrentMana = MaxMana / 2;
    }
}
