using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public int attackDamage;
    public float attackSpeed = 1f;

    private bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        CheckHealth();
    }

    public void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            //Die();
        }
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
