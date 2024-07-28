using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.name == "Table")
        {
              Debug.Log("IT WORKS");

        }

    }
}
