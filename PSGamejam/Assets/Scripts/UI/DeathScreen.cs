using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void Quit(){
        Application.Quit();
    }
    public void TryAgain(){
        SceneManager.LoadScene("MainMenu");
    }
}
