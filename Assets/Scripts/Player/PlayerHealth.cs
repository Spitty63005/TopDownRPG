using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] PlayerStats playerStats;
    PlayerAnimations animations;

    void Awake()
    {
        animations = GetComponent<PlayerAnimations>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
            TakeDamage(2);
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
