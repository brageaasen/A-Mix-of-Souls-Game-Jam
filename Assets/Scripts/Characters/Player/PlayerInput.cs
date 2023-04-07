using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    [Header ("Movement")]
    public KeyCode forward = KeyCode.W;
    public KeyCode back = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode turnLeft = KeyCode.Q;
    public KeyCode turnRight = KeyCode.E;

    
    [Header ("Combat")]
    public KeyCode attack = KeyCode.Mouse0;
    public KeyCode parry = KeyCode.Mouse1;


    private PlayerController controller;
    private Character player;
    private CharacterCombat characterCombat;

    private void Awake()
    {
        this.controller = GetComponent<PlayerController>();
        this.player = GetComponent<Character>();
        this.characterCombat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Input.GetKeyUp(forward)) controller.MoveForward();
        if (Input.GetKeyUp(back)) controller.MoveBackwards();
        if (Input.GetKeyUp(left)) controller.MoveLeft();
        if (Input.GetKeyUp(right)) controller.MoveRight();
        if (Input.GetKeyUp(turnLeft)) controller.RotateLeft();
        if (Input.GetKeyUp(turnRight)) controller.RotateRight();

        // Combat
        if (Input.GetKeyUp(parry)) characterCombat.StartMeleeParry(this.player);
    }
}
