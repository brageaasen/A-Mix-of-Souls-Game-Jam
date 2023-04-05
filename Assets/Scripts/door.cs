using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{

    private bool open;
    private Animator animator;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponentInParent<Animator>();
        this.player = PlayerManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        this.open = true;
        this.animator.SetTrigger("OpenDoor");
    }

    private void OnTriggerStay(Collider other) // "Press F to open" UI
    {
        if (other.tag == "Player")
        {
            Debug.Log(open);
            if (Input.GetKeyDown(KeyCode.F)) // And player has key
            {
                OpenDoor();
            }
        }
    }
}
