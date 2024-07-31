using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Scene = UnityEngine.SceneManagement.Scene;

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
            if (SceneManager.sceneCount > 0)
        {
            for (int n = 0; n < SceneManager.sceneCount; ++n)
            {
                Scene scene = SceneManager.GetSceneAt(n);
                if(scene.name == "CoffeeNCauldronTestScene"){

                }else{
                    SceneManager.UnloadSceneAsync(scene.name);
                    MainScene.Scene.SetActive(true);
                }
                
            }
        }
        }
    }

    void StartTimer(){
        slider.value -= randomTimerValue * Time.deltaTime;
    }
}
