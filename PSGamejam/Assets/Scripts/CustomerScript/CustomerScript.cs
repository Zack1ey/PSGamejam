using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomerScript : MonoBehaviour {

    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;
    private bool playerInRange;
    public GameObject Panel;
    public Button Button;
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
            //Interact Code
            Debug.Log("Interacted");
            if(Panel.activeInHierarchy){
                zeroText();
            }else{
                Panel.SetActive(true);
                StartCoroutine(Typing());
                if(index >= dialogue.Length -1){
                    Button.interactable = true;
                    Debug.Log("Meow");
                }else if(index <= dialogue.Length){
                    Debug.Log(":notmoew");
                }
            }
        }
    }

    IEnumerator Typing() {
        //Type each letter of the string into the text box
            foreach(char letter in dialogue[index].ToCharArray()){
                dialogueText.text += letter;
                //check the length and if they match then enable continue button
                if(dialogueText.text.Length == dialogue[index].Length){
                    Button.interactable=true;
                    break;
                }
                //timer for 0.05 seconds
                yield return new WaitForSeconds(0.05f);
        }
    } 

    void PlayMiniGame(){
        SceneManager.LoadScene("TestMiniGamePickUp");
    }

    void zeroText(){
        dialogueText.text = "";
        index = 0;
        Panel.SetActive(false);
    }

    public void NextLine(){
        if(index == dialogue.Length -1){
            PlayMiniGame();
        }
        if(index < dialogue.Length -1){
            Button.interactable=false;
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
