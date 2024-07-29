
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoliceMovement : MonoBehaviour
{
    private List<Vector3> CopLocations = new List<Vector3>();
    private int PatrolLimit;
    private int PatrolAmount;
    private int index;
    bool PatrolAllowed;
    // Start is called before the first frame update
    void Awake()
    {
        PatrolAllowed = true;
        PatrolLimit = Random.Range(1, 5);
        Debug.Log("Amount "+ PatrolAmount);
        Debug.Log("Limit "+PatrolLimit);
        if(PatrolAmount >= PatrolLimit){
            PatrolLimit++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PatrolAllowed){
            MoveTo();
        }else{
            LeaveCafe();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Table"){
            CopLocations.Add(other.transform.position);    
            Debug.Log("CopLocations: "+CopLocations.Count);
        }
    }

    void MoveTo(){
        if(index < CopLocations.Count){
            transform.position = Vector3.MoveTowards(transform.position, CopLocations[index], 2 * Time.deltaTime);
            if(CheckPosition()){
                index++;
            }
        }else{
            if(PatrolAmount >= PatrolLimit){
                Debug.Log("Leaving");
                PatrolAllowed = false;
            }else{
                PatrolAmount++;
                index = 0;
            }
        }
    }

    bool CheckPosition(){
        if(transform.position == CopLocations[index]){
            return true;
        }
        return false;
    }

    void LeaveCafe(){
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-10,transform.position.y,0), 2 * Time.deltaTime);
        if(transform.position == new Vector3(-10,transform.position.y,0)){
            Destroy(gameObject);
        }
    }
}
