using System.Collections;
using TMPro;
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
    public GameObject PlayerRef;
    private GameObject spawner;


    void Start() {
        
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
            //Interact Code
            if(Panel.activeInHierarchy){
                zeroText();
            }else{
                Panel.SetActive(true);
                StartCoroutine(Typing());
                if(index >= dialogue.Length -1){
                    Button.interactable = true;
                
                }
            }
        }
        if(spawner != null){
            Panel = spawner.GetComponent<CustomerSpawnScript>().Panel;
            dialogueText = spawner.GetComponent<CustomerSpawnScript>().dialogueText;
            Button = spawner.GetComponent<CustomerSpawnScript>().Button;
            PlayerRef = spawner.GetComponent<CustomerSpawnScript>().PlayerRef;
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

    

    void zeroText(){
        dialogueText.text = "";
        index = 0;
        Button.interactable = false;
        if(Panel != null){
        Panel.SetActive(false);
        }
    }

    public void NextLine(){
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
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            playerInRange = true;
        }
        if(other.gameObject.tag =="EditorOnly"){
            spawner = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            playerInRange = false;
            zeroText();
        }
    }

}
