using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CustomerScript : MonoBehaviour {

    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;
    private bool playerInRange;
    public GameObject Panel;
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
            //Interact Code
            Debug.Log("Interacted");
            if(Panel.activeInHierarchy){
                zeroText();
            }else{
                Panel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }

    IEnumerator Typing() {
        foreach(char letter in dialogue[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.15f);
        }
    } 

    void zeroText(){
        dialogueText.text = "";
        index = 0;
        Panel.SetActive(false);
    }

    public void NextLine(){
        if(index < dialogue.Length -1){
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }else{
            zeroText();
        }
    }
    //When player is in collider Zone then change the playerinrange to true or false
    void OnTriggerEnter2D() {
        playerInRange = true;
    }

    void OnTriggerExit2D(){
        playerInRange = false;
        zeroText();
    }

}
