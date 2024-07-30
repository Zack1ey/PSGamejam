using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameButtonScript : MonoBehaviour
{
    private int MiniNum = 3;
    private string MinigameName;
    public List<GameObject> Tables = new List<GameObject>();
    public GameObject SCENE;


    // Update is called once per frame
    public void PlayMinigame(){
        gameObject.SetActive(false);
        MainScene.Scene = SCENE;
        MainScene.Scene.SetActive(false);
        //MiniNum = Random.Range(0, 4);

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
        SceneManager.LoadScene(MinigameName, LoadSceneMode.Additive);
    }
}
