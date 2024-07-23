using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlopWinCondition : MonoBehaviour
{
    private List<Collider2D> overlappingObjects = new List<Collider2D>();
    int ObjectCount;

    void Update(){
        if(ObjectCount >= 2){
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
    }

    void CheckObjects(){
        Debug.Log("Checking");
        foreach (Collider2D obj in overlappingObjects){
            if (obj.gameObject.CompareTag("Potion")){
                ObjectCount++;
                Debug.Log(ObjectCount);
            }
        }
    }
}
