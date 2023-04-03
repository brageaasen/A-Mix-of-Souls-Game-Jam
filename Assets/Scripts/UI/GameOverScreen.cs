using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{

    public GameObject gameOverMenuUI;

    // Reference
    [SerializeField] private Character player;
    
    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            gameOverMenuUI.SetActive(true);
        }
    }
}