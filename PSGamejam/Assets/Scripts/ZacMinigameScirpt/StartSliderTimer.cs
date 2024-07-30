
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSliderTimer : MonoBehaviour
{
    public Slider slider;

    [Header("Time between min and max (Min = Slower)")]
    public float minTime;
    public float maxTime;
    
    private float randomTimerValue;
    // Start is called before the first frame update
    void Start()
    {

        randomTimerValue = Random.Range(minTime,maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        StartTimer();
        if(slider.value <= 0){
            Debug.Log("Failed");
            
        }
    }

    void StartTimer(){
        slider.value -= randomTimerValue * Time.deltaTime;
    }
}
