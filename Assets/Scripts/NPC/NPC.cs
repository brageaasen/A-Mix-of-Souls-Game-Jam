using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    public string[] dialogue2;
    private int index = 0;

    private GameObject player;

    public float wordSpeed;
    public bool playerIsClose;

    private AudioManager audioManager;


    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        dialogueText.text = "";

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                //audioManager.Play("Click");
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dialogue[index])
            {
                //audioManager.Play("Click");
                NextLine();
            }
        }

        // Speed up dialogue
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    wordSpeed /= 4;
        //} else if (Input.GetKeyUp(KeyCode.R))
        //{
        //    wordSpeed *= 4;
        //}

        // Quit dialogue
        if (Input.GetKeyDown(KeyCode.T) && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }        
    }

    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            audioManager.Play("Talk");
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            RemoveText();
            index = 0;
        }
    }
}
