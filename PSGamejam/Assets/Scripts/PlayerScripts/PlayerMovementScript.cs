using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //Create Variables
    [Header("Movement")]
    public float movementSpeed;
    
    //Get Ref to RigidBody component
    [Header("Components")]
    private Rigidbody2D rb;

    [Header("GameRefrence")]
    public TextMeshProUGUI PointsUIText;
    private int playerScore;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = Positioning.PlayerPos;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GetPoints();
    }

    //Move the transform of the character by the direction and movementspeed
    void Movement(){
        
        if(Input.GetKey("d")){
            rb.velocity = Vector2.right*movementSpeed;
            ChangePlayerDirection("Right");
        }
        if(Input.GetKey("a")){
            rb.velocity = Vector2.left*movementSpeed;
            ChangePlayerDirection("Left");
        }
        
    }

    //Change the players looking direction by Movement()
    void ChangePlayerDirection(String Direction){
        if(Direction == "Left"){
            transform.localScale = new Vector3(-1,1,1);
        }else if(Direction == "Right"){
            transform.localScale = new Vector3(1,1,1);
        }
    }

    public void GetPoints(){
        playerScore = Scoring.scorePoints;
        PointsUIText.text = "GOLD:"+ playerScore;
    }
}

