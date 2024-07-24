using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirtyPlate : MonoBehaviour
{
    private Rigidbody2D rb;
    public int DirtCount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 0){
            rb.velocity = new Vector2(0,0);
        }else if(transform.position.y <=0){
            rb.velocity = Vector2.up*8;
        }

        if(PlateCleaned()){
            MovePlate();
        }
    }

    bool PlateCleaned(){
        if(DirtCount == 0){
            return true;
        }
        return false;
    }

    void MovePlate(){
        rb.velocity = Vector2.up*7;
        if(transform.position.y >= 8){
            Scoring.scorePoints += 5;
            SceneManager.LoadScene("CoffeeNCauldronTestScene");
        }
    }
}
