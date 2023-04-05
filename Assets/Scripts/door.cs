using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private bool open;
    private Animator animator;
    private GameObject player;
    private RayCastMove ray;

    private AudioManager audioManager;

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
            if (Input.GetKeyDown(KeyCode.F)) // And player has key
            {
                ray.LookingAtGameObject().GetComponent<Door>().OpenDoor();
            }
        }
    }
    public void OpenDoor()
    {
        if (open != true)
        {
            this.open = true;
            this.animator.SetTrigger("OpenDoor");
            this.audioManager.Play("Door");
        }
    }
}
