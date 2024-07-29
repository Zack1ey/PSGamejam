using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAlerted : MonoBehaviour
{
    private float AlertIncr = .05f;
    public Slider slider;
    private bool PoliceInRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PoliceInRange){
            slider.value += AlertIncr * Time.deltaTime;
        }
        //Debug.Log(PoliceInRange);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Police"){
            PoliceInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Police"){
            PoliceInRange = false;
        }
    }
}
