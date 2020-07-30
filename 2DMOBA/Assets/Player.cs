using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthBar healthBar;
    public ManaBar manaBar;
    public PlayerStats playerStats;
    void Start()
    {
        playerStats.currentHP = playerStats.HP;
        
        healthBar.SetMaxHealth(playerStats.HP);
        healthBar.SetHealth(playerStats.currentHP);

        playerStats.currentMana = playerStats.mana;
        manaBar.SetMaxMana(playerStats.mana);
        manaBar.SetMana(playerStats.currentMana);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("]"))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown("["))
        {
            LoseMana(20);
        }
    }
    void TakeDamage(float damage)
    {
        playerStats.currentHP -= damage;
        if (playerStats.currentHP < 0)
        {
            playerStats.currentHP = 0;
        }
        healthBar.SetHealth(playerStats.currentHP);
    }
    
    void LoseMana(float manaLost)
    {
        playerStats.currentMana -= manaLost;
        if (playerStats.currentMana < 0)
        {
            playerStats.currentMana = 0;
        }
        manaBar.SetMana(playerStats.currentMana);
    }
}
