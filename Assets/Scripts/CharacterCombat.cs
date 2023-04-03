using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public Character currentCharacter;

    // Attacking
    public float attackCooldown;
    bool canAttack = true;

    // Parrying
    private float parryCooldown;
    private float parryTimer;
    public bool isParrying;
    public bool canParry = true;

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
            if (attackCooldown <= 0f)
                canAttack = true;
        }

        if (!canParry)
        {
            parryCooldown -= Time.deltaTime;
            if (parryCooldown <= 0f)
            {
                canParry = true;
            }
        }

        if (isParrying)
        {
            Debug.Log("PARRY");
            parryTimer += Time.deltaTime;
            if (parryTimer > currentCharacter.parryDuration)
                StopMeleeParry(currentCharacter);
        }
        else
        {
            parryTimer = 0f;
        }
    }

    public void MeleeAttack(Character targetCharacter)
    {
        if (canAttack)
        {
            targetCharacter.TakeDamage(currentCharacter.attackDamage);
            attackCooldown = 1 / currentCharacter.attackSpeed;
            canAttack = false;
        }
    }

    public void StartMeleeParry(Character currentCharacter)
    {
        Debug.Log("Can't parry yet");
        if (canParry)
        {
            Debug.Log("Started parrying");
            currentCharacter.CanTakeDamage(false);
            isParrying = true;
        }
    }

    public void StopMeleeParry(Character currentCharacter)
    {
        Debug.Log("Stopped parrying");
        currentCharacter.CanTakeDamage(true);
        parryCooldown = currentCharacter.parrySpeed;
        parryTimer = 0f;
        canParry = false;
        isParrying = false;
    }
}
