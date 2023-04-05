using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                ray.LookingAtGameObject().GetComponent<Chest>().OpenChest();
            }
        }
    }

    public void OpenChest()
    {
        if (open != true)
        {
            this.GetComponent<Fader>().canFade = false;
            this.GetComponent<Fader>().FadeOut();

            this.open = true;
            this.animator.SetTrigger("OpenChest");
            this.audioManager.Play("Chest");
            
            this.GetComponent<Fader>().enabled = false;
        }
    }
}
