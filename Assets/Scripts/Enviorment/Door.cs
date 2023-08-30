using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Refrences
    private Animator animator;
    private GameObject player;
    private RayCastMove ray;
    private AudioManager audioManager;

    [HideInInspector] public bool open;

    // Start is called before the first frame update
    void Start()
    {
        this.audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        this.animator = GetComponentInParent<Animator>();
        this.player = PlayerManager.instance.player;
        this.ray = player.GetComponent<RayCastMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ray.LookingAt() == this.tag)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (player.GetComponent<Inventory>().keys > 0) // Check if player has key
                {
                    ray.LookingAtGameObject().GetComponent<Door>().OpenDoor();
                }
                else
                    audioManager.Play("DoorLocked"); // Locked sound effect
            }
        }
    }

    public void OpenDoor()
    {
        if (this.open != true)
        {
            this.open = true;
            this.animator.SetTrigger("OpenDoor");
            this.audioManager.Play("Door");
            player.GetComponent<Inventory>().DecrementCount("Key");
        }
    }
}
