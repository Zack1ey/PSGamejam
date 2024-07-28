using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTableScript : MonoBehaviour
{

    public GameObject Table;
    public GameObject Customer;
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Customer.transform.position = Vector2.MoveTowards(Customer.transform.position, Table.transform.position, speed);
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.GameObject.name == "Table")
        {
              Debug.Log("IT WORKS");

        }

    }
}
