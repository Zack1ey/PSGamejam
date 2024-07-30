using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZacWinSolution : MonoBehaviour
{
    [Header("Amount of points (Inputed num is doubled)")]
    public int PointReward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D() {
        Debug.Log("W you won fool");
        Scoring.scorePoints += PointReward;
        SceneManager.UnloadSceneAsync("TestMiniGamePickUp");
    }
}
