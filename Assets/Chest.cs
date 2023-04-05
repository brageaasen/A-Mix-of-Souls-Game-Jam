using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
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

    public void OpenChest()
    {
        this.open = true;
        this.animator.SetTrigger("OpenChest");
    }

    private void OnTriggerStay(Collider other) // "Press F to open" UI
    {
        if (other.tag == "Player")
        {
            Debug.Log("Inside");
            if (Input.GetKeyDown(KeyCode.F))
            {
                OpenChest();
            }
        }
    }
}
