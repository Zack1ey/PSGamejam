using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameButtonScript : MonoBehaviour
{
    private int MiniNum;
    private string MinigameName;
    public GameObject PlayerRef;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    public void PlayMinigame(){
        Debug.Log("ButtonPressed");
        MiniNum = Random.Range(0, 4);

        switch (MiniNum) {
            case 0:
                MinigameName = "CleanThePlate";
                break;
            case 1:
                MinigameName = "PlopMinigame";
                break;
            case 2:
                MinigameName = "TestMiniGamePickUp";
                break;
            case 3:
                MinigameName = "GrindTheBeans";
                break;
        }
        Positioning.PlayerPos = PlayerRef.transform.position;
        SceneManager.LoadScene(MinigameName);
    }
}
