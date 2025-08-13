using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerClass : MonoBehaviour
{
     
     public void LoadMiniGame(string miniGameSceneName)
    {
        // Only load if it's not already loaded
        if (!SceneManager.GetSceneByName(miniGameSceneName).isLoaded)
        {
            SceneManager.LoadScene(miniGameSceneName, LoadSceneMode.Additive);
            Debug.Log("Minigame scene loaded: " + miniGameSceneName);
        }
    }

    // Call this to unload the minigame scene when you're done
    public void UnloadMiniGame(string miniGameSceneName)
    {
        if (SceneManager.GetSceneByName(miniGameSceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(miniGameSceneName);
            Debug.Log("Minigame scene unloaded: " + miniGameSceneName);
        }
    }
}
