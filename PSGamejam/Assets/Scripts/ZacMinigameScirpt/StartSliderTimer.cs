
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSliderTimer : MonoBehaviour
{
    public Slider slider;
    private float randomTimerValue;
    // Start is called before the first frame update
    void Start()
    {
        randomTimerValue = Random.Range(0.3f,0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        StartTimer();
        if(slider.value <= 0){
            Debug.Log("Failed");
            SceneManager.LoadScene("CoffeeNCauldronTestScene");
        }
    }

    void StartTimer(){
        slider.value -= randomTimerValue * Time.deltaTime;
    }
}
