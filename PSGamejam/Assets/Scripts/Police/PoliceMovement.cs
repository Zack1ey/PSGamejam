using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PoliceMovement : MonoBehaviour
{
    private List<Vector3> CopLocations = new List<Vector3>();
    private GameObject Table;
    private float Distance1;
    private float Distance2;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CopLocations.Count > 0){
            FindDistance();
        }else{
            
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Table"){
            if(CopLocations.Count < 1){
                CopLocations.Add(other.transform.position);    
            }
        }
    }
    void FindDistance(){
        Distance1 = Vector2.Distance(transform.position, CopLocations[0]);
        Distance2 = Vector2.Distance(transform.position, CopLocations[1]);
        MoveToLocation();
    }
    void MoveToLocation(){
        if(Distance1<Distance2){
            transform.position = Vector2.MoveTowards(transform.position, CopLocations[0], 5 * Time.deltaTime);
        }else{
            transform.position = Vector2.MoveTowards(transform.position, CopLocations[1], 5 * Time.deltaTime);
        }
    }
}
