using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAlert : MonoBehaviour
{
    public GameObject Panel;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value > 0){
            Panel.SetActive(true);
        }else{
            Panel.SetActive(false);
        }
    }
}
