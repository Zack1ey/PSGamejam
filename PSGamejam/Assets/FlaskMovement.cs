using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskMovement : MonoBehaviour
{
    double fluid = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 0, -30);
            fluid -= 1 * Time.deltaTime;
            Debug.Log(fluid);
        }
    }

}
