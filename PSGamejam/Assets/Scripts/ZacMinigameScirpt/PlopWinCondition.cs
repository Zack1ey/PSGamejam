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
    public SpriteRenderer SR;
    private int YellowCount;
    private int RedCount;
    private int GreenCount;
    private int BlueCount;
    private int PurpleCount;
    private int PinkCount;
    private string Choice1;
    private string Choice2;

    void Start(){
        RandomColour();
        TMP.text = "CAN I HAVE: "+ Choice1 + " AND " + Choice2;
    }

    void Update(){
        //Change Beaker colour off whats inside
        ChangePotionColours();
        //If there are 2 objects or more then continue
        if(CheckResult()){
            Scoring.scorePoints = Scoring.scorePoints + 5;
            SceneManager.UnloadSceneAsync("PlopMinigame");
        }
        Debug.Log(overlappingObjects.Count);
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
        BlueCount=0;
        PurpleCount=0;
        PinkCount=0;
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
                case"PurpleMush":
                    PurpleCount++;
                    break;
                case"BlueMush":
                    BlueCount++;
                    break;
                case"PinkMush":
                    PinkCount++;
                    break;
            }
        }
    }
    void RandomColour(){
        Choice1Colour();
        Choice2Colour();
    }
    void Choice1Colour(){
        int randomChoice1 = Random.Range(0, 2);
        
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
    }
    void Choice2Colour(){
        int randomChoice2 = Random.Range(0, 2);
        switch (randomChoice2) {
            case 0:
                Choice2 = "Pink";
                break;
            case 1:
                Choice2 = "Blue";
                break;
            case 2:
                Choice2 = "Purple";
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
        if(Choice2 == "Blue" && BlueCount > 0){
            return true;
        }else if(Choice2 == "Purple" && PurpleCount > 0){
            return true;
        }else if(Choice2 == "Pink" && PinkCount > 0){
            return true;
        }
        return false;
    }
    void ChangePotionColours(){
        //Red

        if(RedCount > 0 && BlueCount > 0){
            SR.color = new Color(.5f,0,.5f);
        }
        if(RedCount > 0 && GreenCount > 0){
            SR.color = new Color(.5f,.2f,0);
        }
        if(RedCount > 0 && YellowCount > 0){
            SR.color = new Color(.5f,.5f,0);
        }
        if(RedCount > 0 && PinkCount > 0){
            SR.color = new Color(.9f,.3f,.7f);
        }
        if(RedCount > 0 && PurpleCount > 0){
            SR.color = new Color(.45f,0,.3f);
        }
        //Blue

        if(BlueCount > 0 && GreenCount > 0){
            SR.color = new Color(.45f,0,.2f);
        }
        if(BlueCount > 0 && PinkCount > 0){
            SR.color = new Color(.36f,.12f,.9f);
        }
        if(BlueCount > 0 && PurpleCount > 0){
            SR.color = new Color(.12f,0,.76f);
        }
        if(BlueCount > 0 && YellowCount > 0){
            SR.color = new Color(.45f,.45f,.45f);
        }
        //Yellow
        if(YellowCount > 0 && PurpleCount > 0){
            SR.color = new Color(.5f,.4f,.2f);
        }
        if(YellowCount > 0 && PinkCount > 0){
            SR.color = new Color(.91f,.78f,.61f);
        }
        if(YellowCount > 0 && GreenCount > 0){
            SR.color = new Color(.4f,.65f,0);
        }
        //Pink

        if(PinkCount > 0 && PurpleCount > 0){
            SR.color = new Color(.4f,.1f,.7f);
        }
        if(PinkCount > 0 && BlueCount > 0){
            SR.color = new Color(.37f,.17f,.98f);
        }
        if(PinkCount > 0 && GreenCount > 0){
            SR.color = new Color(.5f,.52f,.5f);
        }
        //Purple

        if(PurpleCount > 0 && GreenCount > 0){
            SR.color = new Color(.2f,.3f,.4f);
        }

        if(PurpleCount < 0 && GreenCount < 0 && PinkCount < 0 && BlueCount < 0 && YellowCount < 0 && RedCount <0){
            SR.color = new Color(.2f,.2f,.8f);
        }
    }
}
