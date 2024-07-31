using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeanWinCondition : MonoBehaviour
{
    private int TimesHit;
    private int TimesNeeded;
    public AudioSource audioSource;
    public GameObject Stomp;
    public GameObject Coffee;
    private float timerValue = 3;
    public Image SwirlImage;
    // Start is called before the first frame update
    void Start()
    {
        TimesNeeded = Random.Range(1, 10);

    }

    // Update is called once per frame
    void Update()
    {
        timer();
        if(timerValue <= 0){
            Destroy(SwirlImage);
            Debug.Log("Done");
        }
        if (TimesHit > TimesNeeded){
            Scoring.scorePoints += 5;
            MainScene.Scene.SetActive(true);
            SceneManager.UnloadSceneAsync("GrindTheBeans");
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            TimesHit++;
            audioSource.Play();
            Stomp.transform.position = new Vector3(-0.00999999978f,0.519999981f,0);
            Coffee.transform.localScale = new Vector3(1.43865836f,1.08228838f,1);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player") {
            Stomp.transform.position = new Vector3(-0.00999999978f,-0.170000002f,0);
            Coffee.transform.localScale = new Vector3(1.43865836f,0.898508918f,1);
        }
    }
    void timer(){
        timerValue -= 2 * Time.deltaTime;
        
    }
}
