using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonScreen : MonoBehaviour
{

    [SerializeField] private GameObject gameWonMenuUI;

    // Reference
    [SerializeField] private Timer timer;
    private GameObject player;
    private PlayerController playerController;
    private AudioManager audioManager;

    void Start()
    {
        this.player = PlayerManager.instance.player;
        playerController = player.GetComponent<PlayerController>();
        this.audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<AngelCollecter>().angels >= 10) // Check if win conditions are met, if so, show game won screen and disable player
        {
            playerController.canMove = false;
            player.GetComponent<Character>().CanTakeDamage(false);
            player.GetComponent<CharacterCombat>().canAttack = false; // Temporary bad solution to non attack mode for user when game end
            player.GetComponent<CharacterCombat>().attackCooldown = 500f;
            player.GetComponent<CharacterCombat>().canParry = false;
            player.GetComponent<CharacterCombat>().parryCooldown = 500f;
            gameWonMenuUI.SetActive(true);
            timer.StopTimer();
        }
    }

    public void PlaySelectSound()
    {
         audioManager.Play("Select");
    }
}