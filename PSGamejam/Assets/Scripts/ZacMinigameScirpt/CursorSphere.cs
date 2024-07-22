using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSphere : MonoBehaviour
{
    private Vector2 mousePos;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePos.x,mousePos.y);
            
    }

}
