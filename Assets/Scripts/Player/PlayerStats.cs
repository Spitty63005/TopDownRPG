using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int CurrentLevel;
    public float CurrentHealth;
    public float MaxHealth;
}
