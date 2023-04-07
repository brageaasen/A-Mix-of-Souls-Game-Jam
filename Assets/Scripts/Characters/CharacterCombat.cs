using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public Character currentCharacter;
    private Enemy enemy;
    private GameObject player;

    private Inventory inventory;
    public int potionGain = 40;

    // Attacking
    public float attackCooldown;
    public bool canAttack = true;

    // Parrying
    private float parryCooldown;
    private float parryTimer;
    public bool canParry;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        this.audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        this.currentCharacter = GetComponent<Character>();
        this.player = PlayerManager.instance.player;

        if (GetComponent<Inventory>() != null)
            this.inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            UsePotion(this.player.GetComponent<Character>());

        if (!canAttack)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0f)
                canAttack = true;
        }

        if (!canParry && currentCharacter.tag == "Player")
        {
            parryCooldown -= Time.deltaTime;
            if (parryCooldown <= 0f)
            {
                canParry = true;
            }
        }

        if (currentCharacter.isParrying && currentCharacter.tag == "Player")
        {
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
        if (canAttack && !currentCharacter.isParrying)
        {
            if (targetCharacter.isParrying)
            {
                GotParried();
                SuccessfulParry(targetCharacter);
            }
            else
            {
                if (targetCharacter.tag == "Player")
                    audioManager.Play("Enemy");
                else
                    audioManager.Play("Attack");
                
                targetCharacter.TakeDamage(currentCharacter.attackDamage);
                attackCooldown = 1 / currentCharacter.attackSpeed;
                canAttack = false;
            }
        }
    }

    public void StartMeleeParry(Character currentCharacter)
    {
        Debug.Log("Can't parry yet");
        if (canParry)
        {
            currentCharacter.isParrying = true;
        }
    }

    public void StopMeleeParry(Character currentCharacter)
    {
        parryCooldown = currentCharacter.parrySpeed;
        parryTimer = 0f;
        canParry = false;
        currentCharacter.isParrying = false;
    }


    /// <summary>
    /// Stops attack from attacker, and takes damage according to current attack damage. Gets double attack cooldown on next attack.
    /// </summary>
    public void GotParried()
    {
        currentCharacter.TakeDamage(currentCharacter.attackDamage);
        attackCooldown = 2 * (1 / currentCharacter.attackSpeed);
        canAttack = false;

        // UI: Questionmark spin over head
        if (currentCharacter.GetComponent<Enemy>() != null)
        {
            enemy = currentCharacter.GetComponent<Enemy>();
            enemy.EnableQuestionMark();
            Invoke("InvokeDisableFromEnemy", attackCooldown - enemy.reactionTime);
        }
    }

    /// <summary>
    /// If character gets a successfull parry, character gets a new attack instantly. 
    /// </summary>
    public void SuccessfulParry(Character targetCharacter)
    {
        audioManager.Play("Parry");
        targetCharacter.GetComponentInParent<CharacterCombat>().canAttack = true;
        targetCharacter.GetComponentInParent<CharacterCombat>().attackCooldown = 0f;
    }

    private void InvokeDisableFromEnemy()
    {
        enemy.DisableQuestionMark();
    }

    private void UsePotion(Character player)
    {
        if ((this.player.GetComponent<Inventory>().potions > 0) && (player.currentHealth < player.maxHealth))
        {
            player.currentHealth += 40; // Change to variable potionGain
            player.CheckHealth();
            this.player.GetComponent<Inventory>().DecrementCount("Potion");
            audioManager.Play("UsePotion");
        }
    }

}
