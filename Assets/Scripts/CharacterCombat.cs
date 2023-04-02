using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public Character currentCharacter;

    public float attackCooldown;
    bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = GetComponent<Character>();
    }

    void Update()
    {
        if (!canAttack)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
                canAttack = true;
        }
    }

    public void MeleeAttack(Character targetCharacter)
    {
        if (attackCooldown <= 0)
        {
            targetCharacter.TakeDamage(currentCharacter.attackDamage);
            attackCooldown = 1 / currentCharacter.attackSpeed;
            canAttack = false;
        }
    }
}
