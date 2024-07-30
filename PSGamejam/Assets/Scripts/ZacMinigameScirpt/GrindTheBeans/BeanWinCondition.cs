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
            SceneManager.UnloadSceneAsync(2);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            TimesHit++;
            audioSource.Play();
            Stomp.transform.position = new Vector3(4,-2.14f,0.12f);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player") {
            Stomp.transform.position = new Vector3(4,-1.44f,0.1224f);
        }
    }
    void timer(){
        timerValue -= 2 * Time.deltaTime;
        
    }
}
