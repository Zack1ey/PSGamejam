using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerScript : MonoBehaviour {

    public bool playerInRange;
    
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
            //Interact Code
            Debug.Log("Interacted");
        }
    }

    //When player is in collider Zone then change the playerinrange to true or false
    void OnTriggerEnter2D() {
        playerInRange = true;
    }

    void OnTriggerExit2D(){
        playerInRange = false;
    }

}
