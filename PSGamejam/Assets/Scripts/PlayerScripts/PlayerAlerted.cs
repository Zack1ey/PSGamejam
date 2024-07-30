using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAlerted : MonoBehaviour
{
    private float AlertIncr = .01f;
    private float AlertDecr = .005f;
    public Slider slider;
    private List<Collider2D> policeList = new List<Collider2D>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(policeList.Count > 0){
            slider.value += AlertIncr * Time.deltaTime;
        }else{
            slider.value -= AlertDecr * Time.deltaTime;
        }

        if(slider.value >= 1){
            Time.timeScale = .25f;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Police"){
            policeList.Add(other);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Police"){
            policeList.Remove(other);
        }
    }
}
