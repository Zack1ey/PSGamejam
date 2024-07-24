using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DirtySpots : MonoBehaviour
{
    private SpriteRenderer sr;
    
    void Start(){
            sr = GetComponent<SpriteRenderer>();
    }
    void Update(){
        if(sr.color.a == 0){
            GetComponentInParent<DirtyPlate>().DirtCount--;
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer == 6){
            sr.color -= new Color(0, 0, 0, .25f);
        }
    }
}
