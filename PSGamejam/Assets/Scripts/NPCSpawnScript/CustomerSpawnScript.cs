using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class CustomerSpawnScript : MonoBehaviour
{

    [SerializeField]private GameObject customer;
    public GameObject Panel;
    public Button Button;
    public GameObject PlayerRef;
    public TextMeshProUGUI dialogueText;
    private List<GameObject> tables = new List<GameObject>();

    // Start is called before the first frame update

    // Update is called once per frame

    void Start(){
        
    }
    void Update()
    {
        if(tables.Count > 0){
            for(int i = 0; i < tables.Count;i++){
                if(tables[i].GetComponent<TableScript>().GetIsOpen()){
                    Instantiate(customer, transform.position, quaternion.identity,gameObject.transform);
                    tables.Remove(tables[i]);
                    break;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Table"){
            tables.Add(other.gameObject);
            Debug.Log("Table count: "+tables.Count);
        }
    }
}
