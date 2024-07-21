using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //Create Variables
    [Header("Movement")]
    public float movementSpeed;
    
    //Get Ref to RigidBody component
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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

}

