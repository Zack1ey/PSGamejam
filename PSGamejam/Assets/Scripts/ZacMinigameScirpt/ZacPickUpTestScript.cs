using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZacPickUpTestScript : MonoBehaviour
{
    private Vector2 mousePos;
    private Rigidbody2D rb;
    private bool dragable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        //if the user uses mouse button 1 and the cursor is in the collider
        if(Input.GetButton("Fire1")&& dragable){
            rb.simulated = true;
            //move the object to the mouses point on the camera
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(new Vector2(mousePos.x,mousePos.y));
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == 6){dragable = true;}
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.layer == 6){dragable = false;}
    }
}
