using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTableScript : MonoBehaviour
{

    public GameObject Table;
    public GameObject CapPlayer;
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CapPlayer.transform.position = Vector2.MoveTowards(CapPlayer.transform.position, Table.transform.position, speed);
    }
}
