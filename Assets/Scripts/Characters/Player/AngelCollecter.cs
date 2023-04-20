using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngelCollecter : MonoBehaviour
{
    public float angels = 0f;
    public TextMeshProUGUI textAngels;
    private AudioManager audioManager;

    private GameObject player;
    private RayCastMove ray;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        
        player = PlayerManager.instance.player;
        ray = player.GetComponent<RayCastMove>();
    }

    public void IncrementAngelCount()
    {
        angels++;
        textAngels.text = angels.ToString();
    }
    public void DecrementAngelCount()
    {
        if (angels != 0)
        {
            angels--;
            textAngels.text = angels.ToString();
        }
    }

    public void Collect()
    {
        audioManager.Play("PickUp");
        Destroy(ray.LookingAtGameObject());
        IncrementAngelCount();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && (ray.LookingAt() == "Angel") && ray.LookingAtGameObject().GetComponent<NPC>().canBeCollected)
        {
            Collect();
        }
    }
}
