using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Create Play game function to move from Main Menu to the Game Scene.
    public void PlayGame(){
        SceneManager.LoadScene("CoffeeNCauldronTestScene");
    }

    public void CloseGame(){
        Application.Quit();
    }
}
