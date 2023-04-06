using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public float keys = 0f;
    public float potions = 0f;
    public TextMeshProUGUI textKeys;
    public TextMeshProUGUI textPotions;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void IncrementCount(string str)
    {
        if (str == "Key")
        {
            keys++;
            textKeys.text = keys.ToString();
            this.audioManager.Play("PickUp");
        }
        else if (str == "Potion")
        {
            potions++;
            textPotions.text = potions.ToString();
            this.audioManager.Play("PickUp");
        }
    }
    public void DecrementCount(string str)
    {
        if (str == "Key")
        { 
            if (keys > 0)
            {
                keys--;
                textKeys.text = keys.ToString();
            }
        }
        else if (str == "Potion")
        {
            if (potions > 0)
            {
                potions--;
                textPotions.text = potions.ToString();
            }
        }
    }
}
