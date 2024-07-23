using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class PlopWinCondition : MonoBehaviour
{
    private List<Collider2D> overlappingObjects = new List<Collider2D>();
    public TextMeshProUGUI TMP;
    int ObjectCount;
    int YellowCount;
    int RedCount;
    int GreenCount;
    string Choice1;
    string Choice2;

    void Start(){
        RandomColour();
        TMP.text = "CAN I HAVE: "+ Choice1 + " AND " + Choice2;
    }

    void Update(){
        //Change Beaker colour off whats inside
        if(YellowCount >= 1){
            if(RedCount >= 1){
                GetComponent<SpriteRenderer>().color = Color.magenta;
            }else if(GreenCount >= 1){
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 0);
            }else{
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
        else if(RedCount >= 1){
            if(GreenCount >= 1){
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 0);
            }else if(YellowCount >= 1){
                GetComponent<SpriteRenderer>().color = new Color(255, 140, 0);
            }else{
            GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        else if(GreenCount >= 1){
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else{
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        //If there are 2 objects or more then continue
        if(CheckResult()){
            Scoring.scorePoints =+ 5;
            SceneManager.LoadScene("CoffeeNCauldronTestScene");
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        overlappingObjects.Add(other);
        CheckObjects();
    }
    void OnTriggerExit2D(Collider2D other){
        overlappingObjects.Remove(other);
        YellowCount=0;
        RedCount=0;
        GreenCount=0;
        CheckObjects();
    }

    void CheckObjects(){
        Debug.Log("Checking");
        foreach (Collider2D obj in overlappingObjects){
            switch(obj.tag){
                case "YellowMush":
                    YellowCount++;
                    break;
                case "RedMush":
                    RedCount++;
                    break;
                case "GreenMush":
                    GreenCount++;
                    break;  
            }
        }
    }

    void RandomColour(){
        int randomChoice1 = Random.Range(0, 2);
        int randomChoice2 = Random.Range(0, 2);
        switch (randomChoice1) {
            case 0:
                Choice1 = "Yellow";
                break;
            case 1:
                Choice1 = "Red";
                break;
            case 2:
                Choice1 = "Green";
                break;
        }

        switch (randomChoice2) {
            case 0:
                Choice2 = "Yellow";
                break;
            case 1:
                Choice2 = "Red";
                break;
            case 2:
                Choice2 = "Green";
                break;
        }
    }

    bool CheckResult(){
        if(Choice1 == "Yellow" && YellowCount > 0){
            if(CheckResultChoice2()){
                return true;
            }
        }else if(Choice1 == "Red" && RedCount > 0){
            if(CheckResultChoice2()){
                return true;
            }
        }else if(Choice1 == "Green" && GreenCount > 0){
            if(CheckResultChoice2()){
                return true;
            }
        }
        return false;
    }
    bool CheckResultChoice2(){
        if(Choice2 == "Yellow" && YellowCount > 0){
            return true;
        }else if(Choice2 == "Red" && RedCount > 0){
            return true;
        }else if(Choice2 == "Green" && GreenCount > 0){
            return true;
        }
        return false;
    }
}
