using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{

    public GameObject gameOverMenuUI;

    // Reference
    [SerializeField] private Character player;
    private PlayerController playerController;
    [SerializeField] private Timer timer;
    private AudioManager audioManager;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        this.audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead || (timer.GetTime() <= 0))
        {
            playerController.canMove = false;
            player.CanTakeDamage(false);
            player.GetComponent<CharacterCombat>().enabled = false;
            player.GetComponent<CharacterCombat>().canAttack = false;
            player.GetComponent<CharacterCombat>().canParry = false;
            gameOverMenuUI.SetActive(true);
        }
    }

    public void PlaySelectSound()
    {
         audioManager.Play("Select");
    }
}