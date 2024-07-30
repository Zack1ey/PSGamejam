using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    private List<GameObject> Tables = new List<GameObject>();
    private GameObject table;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(table != null){
            transform.position = Vector2.MoveTowards(transform.position, table.transform.position, 2 * Time.deltaTime);
            table.GetComponent<TableScript>().SetIsOpen(false);
        
            if(transform.position == table.transform.position){
                Destroy(gameObject.GetComponent<CustomerMovement>());
            }
        }
        */

        if (Tables.Count>0){
            foreach(GameObject t in Tables){
                if(t.GetComponent<TableScript>().GetIsOpen()){
                    table = t;
                    break;
                }
            }
        }


    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag=="Table"){
            Tables.Add(other.gameObject);
        }
    }
}
