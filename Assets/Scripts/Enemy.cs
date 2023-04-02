using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float radius = 2f;
    GameObject player;
    Character playerCharacter;
    CharacterCombat playerCombat;

    Character currentCharacter;
    CharacterCombat enemyCombat;
    NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player;
        playerCharacter = PlayerManager.instance.player.GetComponent<Character>();
        playerCombat = PlayerManager.instance.player.GetComponent<CharacterCombat>();

        currentCharacter = GetComponent<Character>();
        enemyCombat = GetComponent<CharacterCombat>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        
        if (Input.GetKeyDown(KeyCode.K)) // Testing
        {

            if (distance <= radius)
            {
                if (playerCombat != null)
                    playerCombat.MeleeAttack(currentCharacter);
            }
        }

        if (distance <= navAgent.stoppingDistance)
        {
            enemyCombat.MeleeAttack(playerCharacter);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
