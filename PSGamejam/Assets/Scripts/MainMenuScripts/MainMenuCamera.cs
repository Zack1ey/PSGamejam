using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Camera>().orthographicSize -= .2f * Time.deltaTime;
    }
}
