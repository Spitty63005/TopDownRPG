using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] PlayerStats playerStats;
    PlayerAnimations animations;
    PlayerData playerData;

    void Awake()
    {
        animations = GetComponent<PlayerAnimations>();
        playerData = GetComponent<PlayerData>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(2);

        if (Input.GetKeyDown(KeyCode.Return))
            playerData.PlayerStats.RevivePlayer();
    }

    public void TakeDamage(float amount)
    {
        playerStats.CurrentHealth -= amount;

        if(playerStats.CurrentHealth <= 0 ) 
        {
            Die();
        }
    }
    void Die()
    {
        print("YOU DIED");
        animations.HandleDeadTrigger();
    }
}
