using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    private bool canPause = true;

    [SerializeField] private GameObject pauseMenuUI, gameOverMenuUI, dialoguePanelUI, NPC;
    private AudioManager audioManager;

    void Start()
    {
        this.audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NPC != null)
            canPause = !NPC.GetComponent<NPC>().isTalking; // Can only pause when not currently talking to NPC's

        if (Input.GetKeyDown(KeyCode.Escape) && (gameOverMenuUI.activeSelf == false) && ((gameOverMenuUI.activeSelf == false)) && canPause)
        {
            if (GameIsPaused) 
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void PlaySelectSound()
    {
         audioManager.Play("Select");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        if (NPC != null)
            if (NPC.GetComponent<NPC>().isTalking)
                dialoguePanelUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        dialoguePanelUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
