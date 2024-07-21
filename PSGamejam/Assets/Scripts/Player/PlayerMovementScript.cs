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

    void Movement(){
        if(Input.GetKey("d")){
            rb.velocity = Vector2.right*movementSpeed;
        }
        if(Input.GetKey("a")){
            rb.velocity = Vector2.left*movementSpeed;
        }
    }
}
