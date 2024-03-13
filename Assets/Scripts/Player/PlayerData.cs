using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    public PlayerAnimations playerAnimations;

    public PlayerStats PlayerStats => playerStats;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            print("key");
            PlayerRevive();
        }
            
    }

    public void PlayerRevive()
    {
        print("playerdata");
        playerAnimations.ResetPlayerAnimation();
        PlayerStats.RevivePlayer();
    }
}
