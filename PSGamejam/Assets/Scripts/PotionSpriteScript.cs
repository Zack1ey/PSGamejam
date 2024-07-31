using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpriteScript : MonoBehaviour
{
    private Sprite[] potionSprite;
    private int random;
    // Start is called before the first frame update
    void Start()
    {
        potionSprite = Resources.LoadAll<Sprite>("Potion");
        random = Random.Range(0,5);
        gameObject.GetComponent<SpriteRenderer>().sprite = potionSprite[random];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
